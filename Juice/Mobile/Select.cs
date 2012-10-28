using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile {

	//All select form elements are auto-enhanced, no data-role required
	[TargetControlType(typeof(HtmlSelect))]
	[TargetControlType(typeof(DropDownList))]
	public class Select : Juice.Mobile.Framework.MobileExtender {

		//data-icon	home | delete | plus | arrow-u | arrow-d | check | gear | grid | star | custom | arrow-r | arrow-l | minus | refresh | forward | back | alert | info | search
		[WidgetOption("icon", null)]
		public MobileIcon? Icon { get; set; }

		//data-iconpos	left | right | top | bottom | notext
		[WidgetOption("iconpos", null)]
		public MobileIconPosition? IconPosition { get; set; }
		
		//data-inline	true | false
		[WidgetOption("inline", false)]
		public Boolean Inline { get; set; }

		//data-native-menu	true | false
		[WidgetOption("native-menu", true)]
		public Boolean UseNativeMenu { get; set; }

		//data-overlay-theme	swatch letter (a-z) - overlay theme when the page is opened in a dialog
		[WidgetOption("overlay-theme", null)]
		public String OverlayTheme { get; set; }

		//data-placeholder	true | false - Add to the Option
		[WidgetOption("placeholder", false)]
		public Boolean Placeholder { get; set; }
	}
}
