using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using Juice.Framework;

namespace Juice {

	[ParseChildren(typeof(TabPage), DefaultProperty = "TabPages", ChildrenAsProperties = true)]
	[WidgetEvent("select")]
	public class Tabs : JuiceScriptControl {

		public Tabs() : base("tabs") { }

		#region Widget Options

		/// <summary>
		/// Additional Ajax options to consider when loading tab content (see $.ajax).
		/// Reference: http://jqueryui.com/demos/tabs/#ajaxOptions
		/// </summary>
		[WidgetOption("ajaxOptions", null)]
		public string AjaxOptions { get; set; }

		/// <summary>
		/// Whether or not to cache remote tabs content, e.g. load only once or with every click. Cached content is being lazy loaded, e.g once and only once for the first click. Note that to prevent the actual Ajax requests from being cached by the browser you need to provide an extra cache: false flag to ajaxOptions.
		/// Reference: http://jqueryui.com/demos/tabs/#cache
		/// </summary>
		[WidgetOption("cache", false)]
		public bool Cache { get; set; }

		/// <summary>
		/// Set to true to allow an already selected tab to become unselected again upon reselection.
		/// Reference: http://jqueryui.com/demos/tabs/#collapsible
		/// </summary>
		[WidgetOption("collapsible", false)]
		public bool Collapsible { get; set; }

		/// <summary>
		/// Store the latest selected tab in a cookie. The cookie is then used to determine the initially selected tab if the selected option is not defined. Requires cookie plugin, which can also be found in the development-bundle&gt;external folder from the download builder. The object needs to have key/value pairs of the form the cookie plugin expects as options. Available options (example): { expires: 7, path: '/', domain: 'jquery.com', secure: true }. Since jQuery UI 1.7 it is also possible to define the cookie name being used via name property.
		/// Reference: http://jqueryui.com/demos/tabs/#cookie
		/// </summary>
		[WidgetOption("cookie", null)]
		public string Cookie { get; set; }

		/// <summary>
		/// An array containing the position of the tabs (zero-based index) that should be disabled on initialization.
		/// Reference: http://jqueryui.com/demos/tabs/#disabled
		/// </summary>
		[WidgetOption("disabled", null)]
		[TypeConverter(typeof(Int32ArrayConverter))]
		public int[] DisabledTabs { get; set; }

		/// <summary>
		/// The type of event to be used for selecting a tab.
		/// Reference: http://jqueryui.com/demos/tabs/#event
		/// </summary>
		[WidgetOption("event", "click")]
		public string Event { get; set; }

		/// <summary>
		/// Enable animations for hiding and showing tab panels. The duration option can be a string representing one of the three predefined speeds ("slow", "normal", "fast") or the duration in milliseconds to run an animation (default is "normal").
		/// Reference: http://jqueryui.com/demos/tabs/#fx
		/// </summary>
		[WidgetOption("fx", null)]
		public string Fx { get; set; }

		/// <summary>
		/// If the remote tab, its anchor element that is, has no title attribute to generate an id from, an id/fragment identifier is created from this prefix and a unique id returned by $.data(el), for example "ui-tabs-54".
		/// Reference: http://jqueryui.com/demos/tabs/#idPrefix
		/// </summary>
		[WidgetOption("idPrefix", "ui-tabs-")]
		public string IdPrefix { get; set; }

		/// <summary>
		/// HTML template from which a new tab panel is created in case of adding a tab with the add method or when creating a panel for a remote tab on the fly.
		/// Reference: http://jqueryui.com/demos/tabs/#panelTemplate
		/// </summary>
		[WidgetOption("panelTemplate", "&lt;div&gt;&lt;/div&gt;")]
		public string PanelTemplate { get; set; }

		/// <summary>
		/// Zero-based index of the tab to be selected on initialization. To set all tabs to unselected pass -1 as value.
		/// Reference: http://jqueryui.com/demos/tabs/#selected
		/// </summary>
		[WidgetOption("selected", 0)]
		public int Selected { get; set; }

		/// <summary>
		/// The HTML content of this string is shown in a tab title while remote content is loading. Pass in empty string to deactivate that behavior. An span element must be present in the A tag of the title, for the spinner content to be visible.
		/// Reference: http://jqueryui.com/demos/tabs/#spinner
		/// </summary>
		[WidgetOption("spinner", "&lt;em&gt;Loading&amp;#8230;&lt;/em&gt;")]
		public string Spinner { get; set; }

		/// <summary>
		/// HTML template from which a new tab is created and added. The placeholders #{href} and #{label} are replaced with the url and tab label that are passed as arguments to the add method.
		/// Reference: http://jqueryui.com/demos/tabs/#tabTemplate
		/// </summary>
		[WidgetOption("tabTemplate", "&lt;li&gt;&lt;a href=\"#{href}\"&gt;&lt;span&gt;#{label}&lt;/span&gt;&lt;/a&gt;&lt;/li&gt;")]
		public string TabTemplate { get; set; }

		#endregion

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TemplateContainer(typeof(TabPage))]
		public List<TabPage> TabPages { get; set; }

		#region Widget Events

		/// <summary>
		/// This event is triggered when a tab is shown.
		/// Reference: http://jqueryui.com/demos/tabs/#show
		/// </summary>
		[WidgetEvent("show")]
		public event EventHandler OnSelectedTabChanged;

		#endregion

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Div;
			}
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

			if(TabPages != null) {
				foreach(TabPage page in TabPages) {
					writer.WriteBeginTag("div");

					writer.WriteAttribute("id", page.ClientID);

					writer.Write(HtmlTextWriter.TagRightChar);

					page.TemplateContainer.RenderControl(writer);

					writer.WriteEndTag("div");
				}
			}

			this.RenderEndTag(writer);
		}
	}
}
