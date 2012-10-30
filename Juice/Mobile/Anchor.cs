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

	[TargetControlType(typeof(HtmlAnchor))]
	[TargetControlType(typeof(LinkButton))]
	public class Anchor : LinkBase {

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
		/// Positions the icon in the anchor. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("iconpos", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Positions the icon in the anchor. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.")]
		public MobileIconPosition? IconPosition { get; set; }

	}
}
