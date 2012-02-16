using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Juice.Framework {

	internal sealed class JuiceWidgetState {

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

		private Dictionary<String, Dictionary<String, object>> _allWidgetPostbackOptions;
		private Dictionary<String, Object> _options = new Dictionary<String, Object>();
		private List<WidgetEvent> _events = new List<WidgetEvent>();

		private Dictionary<Control, WidgetHash> PageHashes {
			get {
				var hashes = Widget.Page.Items[_hashesKey] as Dictionary<Control, WidgetHash>;
				if(hashes == null) {
					hashes = new Dictionary<Control, WidgetHash>();
					Widget.Page.Items[_hashesKey] = hashes;
				}
				return hashes;
			}
		}

		public JuiceWidgetState(IWidget widget) {
			Widget = widget;
		}

		public IWidget Widget { get; private set; }

		public IEnumerable<ScriptReference> GetJuiceReferences() {
			return new List<ScriptReference> {
				new ScriptReference("jquery", null),
				new ScriptReference("jquery-ui", null),
				new ScriptReference("amplify", null),
				new ScriptReference("juice", null)
			};
		}

		public void SetWidgetNameOnTarget(IAttributeAccessor targetControl) {
			targetControl.SetAttribute("data-ui-widget", Widget.WidgetName);
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
		public void LoadPostData(string postDataKey, NameValueCollection postCollection) {
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
				if(value != currentValue) {
					// Only set the value if it's different from the original value
					widgetOption.PropertyDescriptor.SetValue(Widget, value);
				}
			}
		}

		public void ParseEverything(Control targetControl) {
			//update by c1 in order to override the handle the custom the option
			//ParseOptions();
			Widget.SaveWidgetOptions();
			ParseEvents();

			//add the widgethash to dictionary
			//AddWidgetHash(targetControl, new WidgetHash(Widget.UniqueID, _options, _events));
			AddWidgetHash(targetControl, new WidgetHash(Widget.UniqueID, Widget.WidgetOptions, _events));

		}

		public void EnsureCssLink() {
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
			var isDebug = HttpContext.Current.IsDebuggingEnabled;
			var href = ScriptManager.GetCurrent(page).EnableCdn
					? isDebug
							? JuiceOptions.CssCdnDebugPath
							: JuiceOptions.CssCdnPath
					: page.ResolveUrl(
							isDebug
									? JuiceOptions.CssDebugPath
									: JuiceOptions.CssPath);
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

				if((currentValue == null && widgetOption.DefaultValue != null) ||
						(currentValue != null && !currentValue.Equals(widgetOption.DefaultValue) && !arraysEqual)) {
					if(widgetOption.RequiresEval) {
						currentValue = "eval('(' +" + currentValue + "+ ')')";
					}

					// Add it to the list of options to include in the rendered client state
					_options.Add(widgetOption.Name, currentValue);
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

			// Add widget events from control events
			_events.AddRange(
					from widgetEvent in TypeDescriptor.GetEvents(Widget.GetType()).OfType<EventDescriptor>()
					let attribute = widgetEvent.Attributes.OfType<WidgetEventAttribute>().SingleOrDefault()
					where attribute != null
					select new WidgetEvent(attribute.Name) {
						PostBackHandler = new Lazy<string>(() =>
								Widget.Page.ClientScript.GetPostBackEventReference(
										new PostBackOptions((Control)Widget, string.Empty) {
											AutoPostBack = true
										})
						)
					}
			);
		}

		private void AddWidgetHash(Control targetControl, WidgetHash hash) {
			if(Widget.Visible) {
				PageHashes[targetControl] = hash;
			}
		}

		private IDictionary<string, object> LoadPostDataForControl(Page page, string widgetClientID) {
			EnsureWidgetPostDataLoaded();
			Dictionary<string, object> widgetState;
			_allWidgetPostbackOptions.TryGetValue(widgetClientID, out widgetState);
			return widgetState;
		}

		private void EnsureWidgetPostDataLoaded() {
			if(_allWidgetPostbackOptions == null) {
				var page = Widget.Page;
				if(page.IsPostBack) {
					var optionsJson = page.Request.Form[_formKey];
					if(!String.IsNullOrEmpty(optionsJson)) {
						var js = new JavaScriptSerializer();
						_allWidgetPostbackOptions = js.Deserialize<Dictionary<String, Dictionary<String, object>>>(optionsJson);
					}
				}
				if(_allWidgetPostbackOptions == null) {
					_allWidgetPostbackOptions = new Dictionary<string, Dictionary<string, object>>();
				}
			}
		}

		private void Page_PreRenderComplete(object sender, EventArgs e) {
			var page = sender as Page;
			if(PageHashes == null || !PageHashes.Any()) {
				return;
			}

			var widgetState = new Dictionary<string, object>();

			foreach(var widgetHash in PageHashes) {
				var autoPostBackWidget = widgetHash.Key as IAutoPostBackWidget;
				var isAutoPostBack = autoPostBackWidget != null && autoPostBackWidget.AutoPostBack;
				var item = new {
					uniqueId = widgetHash.Value.UniqueId,
					options = widgetHash.Value.Options,
					events = (from widgetEvent in widgetHash.Value.Events
										select new WidgetHashClientState {
											Name = widgetEvent.Name,
											PostBackEventReference = isAutoPostBack && widgetEvent.PostBackHandler != null
												? widgetEvent.PostBackHandler.Value
												: null
										}).ToArray()
				};

				widgetState.Add(widgetHash.Key.ClientID, item);
			}

			var serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new[] { new WidgetHashClientStateJavaScriptConverter() });
			var json = serializer.Serialize(widgetState);
			var script = String.Format(CultureInfo.InvariantCulture, _hashScript, json, GetCssUrl(page));

			// Render the state JSON blob to the page and the onsubmit script
			ScriptManager.RegisterClientScriptBlock(page, typeof(JuiceWidgetState), _smKey, script, addScriptTags: true);
			ScriptManager.RegisterOnSubmitStatement(page, typeof(JuiceWidgetState), _smKey, _submitScript);
		}
	}
}