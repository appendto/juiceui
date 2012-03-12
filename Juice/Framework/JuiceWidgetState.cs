using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Juice.Framework {

	public sealed class JuiceWidgetState {

		private static readonly ConcurrentDictionary<Type, IEnumerable<WidgetOption>> _widgetOptionsCache = new ConcurrentDictionary<Type, IEnumerable<WidgetOption>>();
		private const string _hashScript = "// Juice Initialization\n" +
																			 "(function() {{\n" +
																			 "    if(typeof(window.Juice) !== 'undefined' && window.Juice) {{\n" +
																			 "        window.Juice.widgets = {0};\n" +
																			 "        window.Juice.cssUrl = '{1}';\n" +
																			 "    }}\n" +
																			 "}})();";
		private const string _submitScript = "if (typeof(window.Juice) !== 'undefined' && window.Juice) {\n" +
																				 "    window.Juice.onSubmit();\n" +
																				 "}";
		private const string _smKey = "Juice.Script";
		private const string _formKey = "_juiceWidgetOptions";
		private const string _cssLinkId = "_jQueryUICss";
		private static readonly object _hashesKey = new object();
		private static readonly object _pagePreRenderCompleteHandlerKey = new object();

		private List<PostBackHash> _allWidgetPostbackOptions; // this is getting ridiculous
		private Dictionary<String, Object> _options = new Dictionary<String, Object>();
		private List<WidgetEvent> _events = new List<WidgetEvent>();
		private List<String> _encodedOptions = new List<String>();

		private WidgetEvent _dataChangedEvent;

		public IWidget Widget { get; private set; }

		public JuiceWidgetState(IWidget widget) {
			Widget = widget;

			foreach(EventDescriptor widgetEvent in TypeDescriptor.GetEvents(Widget.GetType()).OfType<EventDescriptor>()) {

				WidgetEventAttribute attribute = widgetEvent.Attributes.OfType<WidgetEventAttribute>().SingleOrDefault();

				if(attribute != null && attribute.DataChangedHandler == true) {
					_dataChangedEvent = new WidgetEvent(attribute.Name);
					break;
				}
			}
		}

		private List<WidgetHash> PageHashes {
			get {
				List<WidgetHash> hashes = Widget.Page.Items[_hashesKey] as List<WidgetHash>;
				if(hashes == null) {
					hashes = new List<WidgetHash>();
					Widget.Page.Items[_hashesKey] = hashes;
				}
				return hashes;
			}
		}

		public IEnumerable<ScriptReference> GetJuiceReferences() {
			return new List<ScriptReference> {
				new ScriptReference("jquery", null),
				new ScriptReference("jquery-ui", null),
				new ScriptReference("amplify", null),
				new ScriptReference("juice", null)
			};
		}

		// This has become pure decoration. I still think it's nice to have for developmental purposes/reference. 
		public void SetWidgetNameOnTarget(IAttributeAccessor targetControl) {

			String attr = targetControl.GetAttribute("data-ui-widget") ?? String.Empty;

			if(!attr.Contains(Widget.WidgetName)) {
				attr = String.IsNullOrEmpty(attr) ? Widget.WidgetName : String.Join(",", attr, Widget.WidgetName);

				targetControl.SetAttribute("data-ui-widget", attr);
			}
		}

		public void AddPagePreRenderCompleteHandler() {
			var added = Widget.Page.Items[_pagePreRenderCompleteHandlerKey];
			if(added == null) {
				Widget.Page.PreRenderComplete += Page_PreRenderComplete;
				Widget.Page.Items[_pagePreRenderCompleteHandlerKey] = new object();
			}
		}

		public void SetDefaultOptions() {
			foreach(var widgetOption in GetWidgetOptions(Widget.GetType())) {
				var defaultValue = widgetOption.DefaultValue;
				var currentValue = widgetOption.PropertyDescriptor.GetValue(Widget);
				if(defaultValue != currentValue) {
					widgetOption.PropertyDescriptor.SetValue(Widget, widgetOption.DefaultValue);
				}
			}
		}

		/// <summary>
		/// Loads data from the POST and pushes it onto the control widget properties
		/// </summary>
		/// <remarks>
		/// Takes into account the current option value (the default value) and any changes made by client-side JS (posted control state).
		/// </remarks>
		/// <returns>true, if any data has changed. false, if the data has remained the same.</returns>
		public Boolean LoadPostData() {
			// TODO: Refactor to use the params here
			foreach(var widgetOption in GetWidgetOptions(Widget.GetType())) {
				var currentValue = widgetOption.PropertyDescriptor.GetValue(Widget);
				var value = currentValue; // default to the current value

				// Set value to: Posted value OR leave as default value
				var postedControlState = LoadPostDataForControl(Widget.Page, Widget.ClientID);

				if(postedControlState != null) {
					// Changes were made on the client side for this widget, try to get the value for this option
					postedControlState.TryGetValue(widgetOption.Name, out value);
				}

				// if the HtmlEncoding marker is present, this value will be encoded on the client before it's sent.
				// this provides a means to get around ASP.NET WebForms validation.
				if(widgetOption.HtmlEncoding && value is String && value != null) {
					value = System.Web.HttpUtility.HtmlDecode(value as String);
				}

				if(value != currentValue) {
					// Only set the value if it's different from the original value

					// Because we're using PropertyDescriptor.SetValue, we need to manually trigger the converters associated with the widget options Properties.
					// Messy, until I find a better way.
					object newValue = null;
					TypeConverter converter = widgetOption.PropertyDescriptor.Converter;
					
					if(converter != null) {
						newValue = converter.CanConvertFrom(value.GetType()) ? converter.ConvertFrom(value) : value;
					}
					else {
						newValue = value;
					}
										
					widgetOption.PropertyDescriptor.SetValue(Widget, newValue);
				}
			}

			return false;
		}

		public void ParseEverything(Control targetControl) {
			Widget.SaveWidgetOptions();
			ParseEvents();

			WidgetHash hash = new WidgetHash(Widget, _encodedOptions, _events, targetControl);

			AddWidgetHash(hash);
		}

		internal Dictionary<String, Object> ParseOptions() {

			foreach(var widgetOption in GetWidgetOptions(Widget.GetType())) {
				object currentValue = widgetOption.PropertyDescriptor.GetValue(Widget);

				// we need to test arrays to make sure they're not identical, so we dont render unneeded arrays to the options
				bool arraysEqual =
						currentValue != null
						&& currentValue.GetType().IsArray
						&& widgetOption.DefaultValue != null
						&& widgetOption.DefaultValue.GetType().IsArray
						&& ((IEnumerable<object>)currentValue).ItemsAreEqual((IEnumerable<object>)widgetOption.DefaultValue);

				if((currentValue == null && widgetOption.DefaultValue != null) || (currentValue != null && !currentValue.Equals(widgetOption.DefaultValue) && !arraysEqual)) {
					if(widgetOption.RequiresEval) {
						currentValue = new { eval = true, on = currentValue }; //"eval('(' +" + currentValue + "+ ')')";
					}

					// Add it to the list of options to include in the rendered client state
					_options.Add(widgetOption.Name, currentValue);
				}

				if(widgetOption.HtmlEncoding) {
					_encodedOptions.Add(widgetOption.Name);
				}
			}
			return _options;
		}

		private void ParseEvents() {
			// Add widget events from control type declaration
			_events.AddRange(
					from widgetEvent in TypeDescriptor.GetAttributes(Widget).OfType<WidgetEventAttribute>()
					select new WidgetEvent(widgetEvent.Name)
			);

			IAutoPostBackWidget autoPostBackWidget = Widget as IAutoPostBackWidget;
			Boolean autoPostBack = autoPostBackWidget == null ? false : autoPostBackWidget.AutoPostBack;

			// Add widget events from control events
			foreach(EventDescriptor widgetEvent in TypeDescriptor.GetEvents(Widget.GetType()).OfType<EventDescriptor>()) {

				WidgetEventAttribute attribute = widgetEvent.Attributes.OfType<WidgetEventAttribute>().SingleOrDefault();

				if(attribute == null) {
					continue;
				}

				WidgetEvent @event = new WidgetEvent(attribute.Name);

				@event.CausesPostBack = attribute.AutoPostBack && autoPostBack;
				@event.DataChangedEvent = _dataChangedEvent != null && _dataChangedEvent.Name == @event.Name;

				//String postBackArgument = _dataChangedEvent == null ? @event.Name : (_dataChangedEvent.Name == @event.Name ? String.Empty : @event.Name);

				//PostBackOptions postOptions = new PostBackOptions((Control)Widget, postBackArgument) { AutoPostBack = true };
				//var handler = new Lazy<string>(() => Widget.Page.ClientScript.GetPostBackEventReference(postOptions));

				//@event.PostBackHandler = handler;

				_events.Add(@event);
			}

		}
	
		public void EnsureCssLink() {

			if(Widget.Page.Header == null) {
				throw new InvalidOperationException("The Page or MasterPage must contain a HEAD tag with the 'runat=\"server\"' attribute.");
			}

			if(Widget.Page.Header.FindControl(_cssLinkId) == null) {
				if(Widget.Page.Header == null) {
					throw new InvalidOperationException("The Page or MasterPage must contain a HEAD tag with the 'runat=\"server\"' attribute.");
				}

				var jQueryUiCSS = new HtmlLink {
					ClientIDMode = System.Web.UI.ClientIDMode.Static,
					ID = _cssLinkId,
					Href = GetCssUrl(Widget.Page)
				};
				jQueryUiCSS.Attributes.Add("type", "text/css");
				jQueryUiCSS.Attributes.Add("rel", "stylesheet");

				Widget.Page.Header.Controls.Add(jQueryUiCSS);
			}
		}

		private static string GetCssUrl(Page page) {
			Boolean isDebug = HttpContext.Current.IsDebuggingEnabled;
			String href = ScriptManager.GetCurrent(page).EnableCdn ?
				isDebug ? JuiceOptions.CssCdnDebugPath : JuiceOptions.CssCdnPath :
				page.ResolveUrl(isDebug ? JuiceOptions.CssDebugPath : JuiceOptions.CssPath);

			return href;
		}

		private static IEnumerable<WidgetOption> GetWidgetOptions(Type widgetType) {
			IEnumerable<WidgetOption> widgetOptions;
			if(!_widgetOptionsCache.TryGetValue(widgetType, out widgetOptions)) {
				widgetOptions = (from property in TypeDescriptor.GetProperties(widgetType).OfType<PropertyDescriptor>()
												 let attribute = property.Attributes.OfType<WidgetOptionAttribute>().SingleOrDefault()
												 where attribute != null
												 select attribute.GetWidgetOption(property)).ToList();
				_widgetOptionsCache.TryAdd(widgetType, widgetOptions);
			}
			return widgetOptions;
		}

		private void AddWidgetHash(WidgetHash hash) {
			if(Widget.Visible) {
				PageHashes.Add(hash);
			}
		}

		private IDictionary<string, object> LoadPostDataForControl(Page page, string widgetClientID) {
			EnsureWidgetPostDataLoaded();
			Dictionary<string, object> widgetState;
			
			//_allWidgetPostbackOptions.TryGetValue(widgetClientID, out widgetState);

			widgetState = (from hash in _allWidgetPostbackOptions
										 where hash.ControlID == widgetClientID && hash.WidgetName == this.Widget.WidgetName
										 select hash.Options).FirstOrDefault() ?? new Dictionary<string, object>();

			return widgetState;
		}

		private void EnsureWidgetPostDataLoaded() {
			if(_allWidgetPostbackOptions == null) {
				var page = Widget.Page;
				if(page.IsPostBack) {
					var optionsJson = page.Request.Form[_formKey];
					if(!String.IsNullOrEmpty(optionsJson)) {
						var js = new JavaScriptSerializer();

						js.RegisterConverters(new JavaScriptConverter[] { new JavaScriptConverters.PostBackHashConverter() });

						_allWidgetPostbackOptions = js.Deserialize<List<PostBackHash>>(optionsJson);
					}
				}
				if(_allWidgetPostbackOptions == null) {
					_allWidgetPostbackOptions = new List<PostBackHash>();
				}
			}
		}

		private void Page_PreRenderComplete(object sender, EventArgs e) {
			var page = sender as Page;
			if(PageHashes == null || !PageHashes.Any()) {
				return;
			}

			List<object> widgetState = new List<object>();

			foreach(WidgetHash widgetHash in PageHashes) {
				//var autoPostBackWidget = widgetHash.TargetControl as IAutoPostBackWidget;
				//var isAutoPostBack = autoPostBackWidget != null && autoPostBackWidget.AutoPostBack;
				var item = new {
					widgetName = widgetHash.WidgetName,
					id = widgetHash.TargetControl.ClientID,
					uniqueId = widgetHash.TargetControl.UniqueID,
					options = widgetHash.Options,
					encodedOptions = widgetHash.EncodedOptions,
					events = (from @event in widgetHash.Events where @event.CausesPostBack == false select @event.Name),
					postBacks = (from @event in widgetHash.Events
											 where @event.CausesPostBack == true
											 select new {
												 name = @event.Name,
												 //causePostBack = true, < moving this to the js
												 dataChangedEvent = @event.DataChangedEvent
											 }).ToArray()
					//select new WidgetHashClientState {
					//  Name = widgetEvent.Name,
					//  PostBackEventReference = isAutoPostBack && widgetEvent.PostBackHandler != null ? widgetEvent.PostBackHandler.Value : null
					//}).ToArray()
				};

				widgetState.Add(item);
			}

			JavaScriptSerializer serializer = new JavaScriptSerializer();

			//serializer.RegisterConverters(new[] { new WidgetHashClientStateJavaScriptConverter() });

			String json = serializer.Serialize(widgetState);
			String script = String.Format(CultureInfo.InvariantCulture, _hashScript, json, GetCssUrl(page));

			// Render the state JSON blob to the page and the onsubmit script
			ScriptManager.RegisterClientScriptBlock(page, typeof(JuiceWidgetState), _smKey, script, addScriptTags: true);
			ScriptManager.RegisterOnSubmitStatement(page, typeof(JuiceWidgetState), _smKey, _submitScript);
		}

		public void RaisePostBackEvent(String eventName) {

			LoadPostData();

			Type type = Widget.GetType();

			foreach(EventDescriptor @event in TypeDescriptor.GetEvents(type).OfType<EventDescriptor>()) {

				WidgetEventAttribute attribute = @event.Attributes.OfType<WidgetEventAttribute>().SingleOrDefault();

				if(attribute == null || attribute.Name != eventName) {
					continue;
				}

				FieldInfo delegateField = type.GetField(@event.Name, BindingFlags.Instance | BindingFlags.NonPublic);
				MulticastDelegate @delegate = delegateField.GetValue(Widget) as MulticastDelegate;

				if(@delegate != null && @delegate.GetInvocationList().Length > 0) {
					@delegate.DynamicInvoke(new object[]{ Widget, EventArgs.Empty });
				}

			}
		}
	}
}