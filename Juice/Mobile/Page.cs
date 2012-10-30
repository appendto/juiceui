using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {

	/// <summary>
	/// Container with data-role="page".
	/// </summary>
	[ParseChildren(false)]
	public class Page : ThemeControlBase {

		public Page() : base("page") { }

		/// <summary>
		/// Add a back button to the page.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("add-back-btn", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Add a back button to the page.")]
		public Boolean AddBackButton { get; set; }

		/// <summary>
		/// Text of the back button.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("back-btn-text", "Back")]
		[Category("Behavior")]
		[DefaultValue("Back")]
		[Description("Text of the back button.")]
		public String BackButtonText { get; set; }

		/// <summary>
		/// Sets the color scheme (swatch) for the back button.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("back-btn-theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Sets the color scheme (swatch) for the back button.")]
		public String BackButtonTheme { get; set; }

		/// <summary>
		/// Text for the close button, dialog only
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("close-btn-text", "Close")]
		[Category("Appearance")]
		[DefaultValue("Close")]
		[Description("text for the close button, dialog only.")]
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

		//data-fullscreen	true | false (used in conjunction with fixed toolbars)
		/// <summary>
		/// Used in conjunction with fixed toolbars.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("fullscreen", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Used in conjunction with fixed toolbars.")]
		public Boolean Fullscreen { get; set; }

		/// <summary>
		/// Overlay theme when the page is opened in a dialog.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("overlay-theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("overlay theme when the page is opened in a dialog.")]
		public String OverlayTheme { get; set; }

		//data-title	string (title used when page is shown)
		/// <summary>
		/// Title used when page is shown.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("title", "Juice UI Mobile Dialog")]
		[Category("Appearance")]
		[DefaultValue("Juice UI Mobile Dialog")]
		[Description("Title used when page is shown.")]
		public String Title { get; set; }
	}
}
