using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {

	//Container with data-role="page"
	public class Page : ThemeControlBase {

		public Page() : base("page") { }

		//data-add-back-btn	true | false (auto add back button, header only)
		[WidgetOption("add-back-btn", false)]
		public Boolean AddBackButton { get; set; }

		//data-back-btn-text	string
		[WidgetOption("back-btn-text", "Back")]
		public String BackButtonText { get; set; }

		//data-back-btn-theme	swatch letter (a-z)
		[WidgetOption("back-btn-theme", null)]
		public String BackButtonTheme { get; set; }

		//data-close-btn-text	string (text for the close button, dialog only)
		[WidgetOption("close-btn-text", "Close")]
		public String CloseButtonText { get; set; }

		//data-dom-cache	true | false
		[WidgetOption("dom-cache", false)]
		public Boolean DomCache { get; set; }

		//data-fullscreen	true | false (used in conjunction with fixed toolbars)
		[WidgetOption("fullscreen", false)]
		public Boolean Fullscreen { get; set; }

		//data-overlay-theme	swatch letter (a-z) - overlay theme when the page is opened in a dialog
		[WidgetOption("overlay-theme", null)]
		public String OverlayTheme { get; set; }

		//data-title	string (title used when page is shown)
		[WidgetOption("title", "Juice UI Mobile Dialog")]
		public String Title { get; set; }

	}
}
