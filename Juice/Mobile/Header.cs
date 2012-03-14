using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {

	//Container with data-role="header"
	public class Header : ThemeControlBase {

		public Header() : base("header") { }

		//data-position	fixed
		[WidgetOption("position", null)]
		public MobilePosition Position { get; set; }

	}
}
