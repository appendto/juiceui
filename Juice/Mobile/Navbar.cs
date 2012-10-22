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
		public MobileIcon? Icon { get; set; }
		
		//data-iconpos	left | right | top | bottom | notext
		[WidgetOption("iconpos", null)]
		public MobileIconPosition? IconPosition { get; set; }

		protected override void Render(HtmlTextWriter writer) {

			this.RenderBeginTag(writer);

			writer.RenderBeginTag(HtmlTextWriterTag.Ul);

			this.RenderChildren(writer);

			writer.RenderEndTag();

			this.RenderEndTag(writer);
		}
	}
}
