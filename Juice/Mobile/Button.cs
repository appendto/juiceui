using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {

	/// <summary>
	/// Links with data-role="button". Input-based buttons and button elements are auto-enhanced, no data-role required
	/// </summary>
	public class Button : LinkBase {

		//data-corners	true | false
		[WidgetOption("corners", true)]
		public Boolean Corners { get; set; }

		//data-icon	home | delete | plus | arrow-u | arrow-d | check | gear | grid | star | custom | arrow-r | arrow-l | minus | refresh | forward | back | alert | info | search
		[WidgetOption("icon", DefaultValue = null)]
		public MobileIcon Icon { get; set; }

		//data-iconpos	left | right | top | bottom | notext
		[WidgetOption("iconpos", null)]
		public MobileIconPosition IconPosition { get; set; }

		//data-iconshadow	true | false
		[WidgetOption("iconshadow", true)]
		public Boolean IconShadow { get; set; }

		//data-inline	true | false
		[WidgetOption("inline", false)]
		public Boolean Inline { get; set; }

		//data-mini	true | false - Compact sized version
		/// <summary>
		/// Display the button in a compact size.
		/// </summary>
		[WidgetOption("mini", false)]
		public Boolean Mini { get; set; }

		//data-shadow	true | false
		[WidgetOption("shadow", true)]
		public Boolean Shadow { get; set; }

		//data-theme	swatch letter (a-z)
		[WidgetOption("theme", null)]
		public String Theme { get; set; }

	}
}
