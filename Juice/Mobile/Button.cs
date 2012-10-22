using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile {

	/// <summary>
	/// Links with data-role="button". Input-based buttons and button elements are auto-enhanced, no data-role required
	/// </summary>
	[TargetControlType(typeof(HtmlAnchor))]
	[TargetControlType(typeof(HtmlButton))]
	[TargetControlType(typeof(HtmlInputButton))]
	[TargetControlType(typeof(Button))]
	[TargetControlType(typeof(LinkButton))]
	public class Button : LinkBase {

		//data-corners	true | false
		[WidgetOption("corners", true)]
		public Boolean Corners { get; set; }

		//data-icon	home | delete | plus | arrow-u | arrow-d | check | gear | grid | star | custom | arrow-r | arrow-l | minus | refresh | forward | back | alert | info | search
		[WidgetOption("icon", null)]
		public MobileIcon? Icon { get; set; }

		//data-iconpos	left | right | top | bottom | notext
		[WidgetOption("iconpos", null)]
		public MobileIconPosition? IconPosition { get; set; }

		//data-iconshadow	true | false
		[WidgetOption("iconshadow", true)]
		public Boolean IconShadow { get; set; }

		//data-inline	true | false
		[WidgetOption("inline", false)]
		public Boolean Inline { get; set; }

		//data-shadow	true | false
		[WidgetOption("shadow", true)]
		public Boolean Shadow { get; set; }

	}
}
