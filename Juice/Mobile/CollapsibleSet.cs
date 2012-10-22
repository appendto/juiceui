using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {

	//A number of collapsibles wrapped in a container with the data-role="collapsible-set"
	[ParseChildren(false)]
	public class CollapsibleSet : ThemeControlBase {

		public CollapsibleSet() : base("collapsible-set") { }

		//data-content-theme	swatch letter (a-z) - Sets all collapsibles in set
		[WidgetOption("content-theme", null)]
		public String ContentTheme { get; set; }

		//data-mini	true | false - Compact sized version
		[WidgetOption("mini", false)]
		public Boolean Mini { get; set; }

		[WidgetOption("inset", true)]
		public Boolean Inset { get; set; }
	}
}
