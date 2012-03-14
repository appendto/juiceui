using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {

	//A number of LIs wrapped in a container with data-role="navbar"
	[ParseChildren(typeof(NavbarItem))]
	public class Navbar : ThemeControlBase {

		public Navbar() : base("navbar") { }

		//data-icon	home | delete | plus | arrow-u | arrow-d | check | gear | grid | star | custom | arrow-r | arrow-l | minus | refresh | forward | back | alert | info | search
		[WidgetOption("icon", null)]
		public MobileIcon Icon { get; set; }
		
		//data-iconpos	left | right | top | bottom | notext
		[WidgetOption("iconpos", "left")]
		public MobileIconPosition IconPosition { get; set; }
	}
}
