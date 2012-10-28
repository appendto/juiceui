﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Juice.Framework;

namespace Juice.Mobile {

	//Page with data-role="page" linked to with data-rel="dialog" on the anchor.
	[TargetControlType(typeof(HtmlAnchor))]
	[TargetControlType(typeof(LinkButton))]
	public class Dialog : Juice.Mobile.Framework.MobileExtender {

		public Dialog() : base() { }

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

		[WidgetOption("transition", null)]
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
