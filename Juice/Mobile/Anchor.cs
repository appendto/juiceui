using System;
using System.Collections.Generic;
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
		[WidgetOption("icon", DefaultValue = null)]
		public MobileIcon? Icon { get; set; }

		//data-iconpos	left | right | top | bottom | notext
		[WidgetOption("iconpos", null)]
		public MobileIconPosition? IconPosition { get; set; }

	}
}
