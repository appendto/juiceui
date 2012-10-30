using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		/// <summary>
		/// Applies an icon from the icon set.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("icon", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Applies an icon from the icon set.")]
		public MobileIcon? Icon { get; set; }

		//data-iconpos	left | right | top | bottom | notext
		/// <summary>
		/// Positions the icon in the button. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("iconpos", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Positions the icon in the button. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.")]
		public MobileIconPosition? IconPosition { get; set; }
		
		//data-inline	true | false
		/// <summary>
		/// Display the control inline, horizontally.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("inline", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Display the control inline, horizontally.")]
		public Boolean Inline { get; set; }

		//data-native-menu	true | false
		/// <summary>
		/// Display the native OS menu.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("native-menu", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Display the native OS menu.")]
		public Boolean UseNativeMenu { get; set; }

		//data-overlay-theme	swatch letter (a-z) - overlay theme when the page is opened in a dialog
		/// <summary>
		/// Overlay theme for non-native selects
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("overlay-theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Overlay theme for non-native selects")]
		public String OverlayTheme { get; set; }

		//data-placeholder	true | false - Add to the Option
		/// <summary>
		/// Can be set on option element of a non-native select
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("placeholder", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Can be set on option element of a non-native select")]
		public Boolean Placeholder { get; set; }
	}
}
