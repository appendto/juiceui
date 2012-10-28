using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {

	//A heading and content wrapped in a container with the data-role="collapsible"
	public class Collapsible : ThemeControlBase {

		public Collapsible() : base("collapsable") {

		}

		//data-collapsed	true | false
		[WidgetOption("collapsed", true)]
		public Boolean Collapsed { get; set; }

		//data-content-theme	swatch letter (a-z)
		[WidgetOption("content-theme", null)]
		public String ContentTheme { get; set; }

		//data-mini	true | false - Compact sized version
		[WidgetOption("mini", false)]
		public Boolean Mini { get; set; }
	}
}
