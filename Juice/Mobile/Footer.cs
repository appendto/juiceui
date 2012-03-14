using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {

	//Container with data-role="footer"
	public class Footer : ThemeControlBase {

		public Footer() : base("footer") { }

		//data-id	string (unique id, useful in persistent footers)
		[WidgetOption("id", null)]
		internal String DataId { get { return Guid.NewGuid().ToString();  } }

		//data-position	fixed
		[WidgetOption("position", null)]
		public MobilePosition Position { get; set; }

	}
}
