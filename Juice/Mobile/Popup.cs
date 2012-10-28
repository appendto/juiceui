using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Juice.Framework;

namespace Juice.Mobile {

	//Container with data-role="header"
	[ParseChildren(false)]
	public class Popup : ThemeControlBase {

		public Popup() : base("popup") { }

		//data-corners	true | false
		[WidgetOption("corners", true)]
		public Boolean Corners { get; set; }

		[WidgetOption("dismissable", true)]
		public Boolean Dismissable { get; set; }

		//data-overlay-theme	swatch letter (a-z) - overlay theme when the page is opened in a dialog
		[WidgetOption("overlay-theme", null)]
		public String OverlayTheme { get; set; }

		[WidgetOption("shadow", true)]
		public Boolean Shadow { get; set; }

		[WidgetOption("tolerance", null)]
		[TypeConverter(typeof(Juice.Mobile.Framework.TypeConverters.MobileToleranceConverter))]
		public Juice.Mobile.Framework.MobileTolerance Tolerance { get; set; }
	}
}
