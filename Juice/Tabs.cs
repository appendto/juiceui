using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using Juice.Framework;
using Juice.Framework.TypeConverters;

namespace Juice {

	[ParseChildren(typeof(TabPage), DefaultProperty = "TabPages", ChildrenAsProperties = true)]
	[WidgetEvent("beforeLoad")]	
	[WidgetEvent("create")]
	[WidgetEvent("beforeActivate")]
	[WidgetEvent("load")]
	public class Tabs : JuiceScriptControl, IAutoPostBackWidget {

		private List<TabPage> _tabPages;

		public Tabs() : base("tabs") {
			_tabPages = new List<TabPage>();
		}

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TemplateContainer(typeof(TabPage))]
		public List<TabPage> TabPages { get { return this._tabPages; } }

		#region Widget Options

		/// <summary>
		/// Set to true to allow an already selected tab to become unselected again upon reselection.
		/// Reference: http://api.jqueryui.com/tabs/#option-collapsible
		/// </summary>
		[WidgetOption("collapsible", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Set to true to allow an already selected tab to become unselected again upon reselection.")]
		public bool Collapsible { get; set; }

		/// <summary>
		/// OBSOLETE. Store the latest selected tab in a cookie. The cookie is then used to determine the initially selected tab if the selected option is not defined. Requires cookie plugin, which can also be found in the development-bundle>external folder from the download builder. The object needs to have key/value pairs of the form the cookie plugin expects as options. Available options (example): { expires: 7, path: '/', domain: 'jquery.com', secure: true }. Since jQuery UI 1.7 it is also possible to define the cookie name being used via name property.
		/// Reference: http://api.jqueryui.com/tabs/#option-cookie
		/// </summary>
		[Obsolete("This option will be removed in jQuery UI 1.10.")]
		public string Cookie { get; set; }

		/// <summary>
		/// Disables (true) or enables (false) the widget.
		/// - OR -
		/// An array containing the position of the tabs (zero-based index) that should be disabled on initialization.
		/// Reference: http://api.jqueryui.com/tabs/#option-disabled
		/// </summary>
		/*
		 * This is really a one-time case specifically for the tabs widget. No other jQuery UI widgets double up on the disabled option.
		 */
		[WidgetOption("disabled", false)]
		[TypeConverter(typeof(BooleanInt32ArrayConverter))]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Disables (true) or enables (false) the widget. - OR - An array containing the position of the tabs (zero-based index) that should be disabled on initialization.")]
		public dynamic Disabled { get; set; }

		/// <summary>
		/// The type of event to be used for selecting a tab.
		/// Reference: http://api.jqueryui.com/tabs/#option-event
		/// </summary>
		[WidgetOption("event", "click")]
		[Category("Behavior")]
		[DefaultValue("click")]
		[Description("The type of event to be used for selecting a tab.")]
		public string Event { get; set; }

		/// <summary>
		/// Controls the height of the accordion and each panel. Possible values: 
		/// "auto": All panels will be set to the height of the tallest panel. 
		/// "fill": Expand to the available height based on the accordion's parent height. 
		/// "content": Each panel will be only as tall as its content.
		/// Reference: http://api.jqueryui.com/tabs/#option-heightstyle
		/// </summary>
		[WidgetOption("heightStyle", "{}", Eval = true)]
		[TypeConverter(typeof(Framework.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{}")]
		[Description(@"Controls the height of the tabs and each panel. Possible values: 
""auto"": All panels will be set to the height of the tallest panel. 
""fill"": Expand to the available height based on the tabs' parent height. 
""content"": Each panel will be only as tall as its content.")]
		public string HeightStyle { get; set; }

		/// <summary>
		/// Specifies if and how to animate the hiding of the panel.
		/// Reference: http://api.jqueryui.com/tabs/#option-hide
		/// </summary>
		[WidgetOption("hide", null)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Specifies if and how to animate the hiding of the panel.")]
		public dynamic Hide { get; set; }

		/// <summary>
		/// Specifies if and how to animate the showing of the panel.
		/// Reference: http://api.jqueryui.com/tabs/#option-hide
		/// </summary>
		[WidgetOption("hide", null)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Specifies if and how to animate the showing of the panel.")]
		public dynamic Hide { get; set; }

		/// <summary>
		/// OBSOLETE. If the remote tab, its anchor element that is, has no title attribute to generate an id from, an id/fragment identifier is created from this prefix and a unique id returned by $.data(el), for example "ui-tabs-54".
		/// Reference: http://api.jqueryui.com/tabs/#option-idPrefix
		/// </summary>
		[Obsolete("This option will be removed in jQuery UI 1.10.")]
		public string IdPrefix { get; set; }

		/// <summary>
		/// OBSOLETE. HTML template from which a new tab panel is created in case of adding a tab with the add method or when creating a panel for a remote tab on the fly.
		/// Reference: http://api.jqueryui.com/tabs/#option-panelTemplate
		/// </summary>
		[Obsolete("This option will be removed in jQuery UI 1.10.")]
		public string PanelTemplate { get; set; }

		/// <summary>
		/// Zero-based index of the tab to be selected on initialization. To set all tabs to unselected pass -1 as value.
		/// Reference: http://api.jqueryui.com/tabs/#option-selected
		/// </summary>
		[WidgetOption("active", 0)]
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Zero-based index of the tab to be selected on initialization. To set all tabs to unselected pass -1 as value.")]
		public int Active { get; set; }
		
		/// <summary>
		/// OBSOLETE. The HTML content of this string is shown in a tab title while remote content is loading. Pass in empty string to deactivate that behavior. An span element must be present in the A tag of the title, for the spinner content to be visible.
		/// Reference: http://api.jqueryui.com/tabs/#option-spinner
		/// </summary>
		[Obsolete("This option will be removed in jQuery UI 1.10.")]
		public string Spinner { get; set; }

		/// <summary>
		/// OBSOLETE. HTML template from which a new tab is created and added. The placeholders #{href} and #{label} are replaced with the url and tab label that are passed as arguments to the add method.
		/// Reference: http://api.jqueryui.com/tabs/#option-tabTemplate
		/// </summary>
		[Obsolete("This option will be removed in jQuery UI 1.10.")]
		public string TabTemplate { get; set; }

		#endregion

		#region Obsolete Widget Options

		[Obsolete("This property has been deprecated in jQuery UI 1.9. Use Active instead.", true)]
		public int Selected { get; set; }

		[Obsolete("This property has been deprecated in jQuery UI 1.9. Use beforeLoad instead. See: http://stage.jqueryui.com/upgrade-guide/1.9/#deprecated-ajaxoptions-and-cache-options-added-beforeload-event", true)]
		public string AjaxOptions { get; set; }

		[Obsolete("This property has been deprecated in jQuery UI 1.9. Use beforeLoad instead. See: http://stage.jqueryui.com/upgrade-guide/1.9/#deprecated-ajaxoptions-and-cache-options-added-beforeload-event", true)]
		public bool Cache { get; set; }

		[Obsolete("This property has been deprecated in jQuery UI 1.9. Use Hide or Show instead.", true)]
		public string Fx { get; set; }

		#endregion

		#region Widget Events

		/// <summary>
		/// This event is triggered when clicking a tab.
		/// Reference: http://api.jqueryui.com/tabs/#event-select
		/// </summary>
		[WidgetEvent("activate", AutoPostBack = true)]
		[Category("Action")]
		[Description("This event is triggered when clicking a tab.")]
		public event EventHandler ActiveTabChanged;

		[Obsolete("This event has been deprecated in jQuery UI 1.9. Use ActiveTabChanged instead.", true)]
		public event EventHandler SelectedTabChanged;

		#endregion

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Div;
			}
		}

		public override ControlCollection Controls {
			get {
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		protected override void OnPreRender(EventArgs e) {

			this.Controls.Clear();

			if(TabPages != null) {
				foreach(TabPage page in TabPages) {
					this.Controls.Add(page);
				}
			}

			base.OnPreRender(e);
		}

		protected override void Render(HtmlTextWriter writer) {

			this.RenderBeginTag(writer);

			writer.WriteBeginTag("ul");

			writer.Write(HtmlTextWriter.TagRightChar);

			if(TabPages != null) {
				foreach(TabPage page in TabPages) {
					writer.WriteFullBeginTag("li");

					writer.WriteBeginTag("a");
					writer.WriteAttribute("href", "#" + page.ClientID);
					writer.Write(HtmlTextWriter.TagRightChar);
					writer.Write(page.Title);
					writer.WriteEndTag("a");

					writer.WriteEndTag("li");
				}
			}

			writer.WriteEndTag("ul");

			this.RenderChildren(writer);

			this.RenderEndTag(writer);
		}
	}
}
