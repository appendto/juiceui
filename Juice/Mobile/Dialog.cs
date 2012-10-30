using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Juice.Framework;

namespace Juice.Mobile {

	/// <summary>
	/// Any page can be presented as a modal dialog by adding the data-rel="dialog" attribute to the page anchor link.
	/// </summary>
	[TargetControlType(typeof(HtmlAnchor))]
	[TargetControlType(typeof(LinkButton))]
	public class Dialog : Juice.Mobile.Framework.MobileExtender {

		public Dialog() : base() { }

		/// <summary>
		/// Customizes the text of the close button which is helpful for translating this into different languages.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("close-btn-text", "Close")]
		[Category("Data")]
		[DefaultValue("Close")]
		[Description("Customizes the text of the close button which is helpful for translating this into different languages.")]
		public String CloseButtonText { get; set; }

		/// <summary>
		/// Apply dom-cache.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("dom-cache", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Apply dom-cache.")]
		public Boolean DomCache { get; set; }

		/// <summary>
		/// Show dialog in fullscreen.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("fullscreen", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Show dialog in fullscreen.")]
		public Boolean Fullscreen { get; set; }

		/// <summary>
		/// Overlay theme when the page is opened in a dialog.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("overlay-theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Overlay theme when the page is opened in a dialog.")]
		public String OverlayTheme { get; set; }

		/// <summary>
		/// Title used when page is shown.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("title", "")]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("Title used when page is shown.")]
		public String Title { get; set; }

		/// <summary>
		/// By default, the dialog will open with a 'pop' transition.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("transition", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("By default, the dialog will open with a 'pop' transition.")]
		public MobileTransition? Transition { get; set; }

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);

			if(TargetControl != null) {
				var accessor = TargetControl as IAttributeAccessor;
				if(accessor != null){
					accessor.SetAttribute("data-rel", "dialog");
				}
			}
		}
	}
}
