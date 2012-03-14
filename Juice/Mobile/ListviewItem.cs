using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {
	
	//LI within a listview
	public class ListviewItem : ThemeControlBase {

		public ListviewItem() : base("list-divider") { }

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.Li; } }

		//data-filtertext	string (filter by this value instead of inner text)
		[WidgetOption("filtertext", null)]
		public String FilterText { get; set; }

		//data-icon	home | delete | plus | arrow-u | arrow-d | check | gear | grid | star | custom | arrow-r | arrow-l | minus | refresh | forward | back | alert | info | search
		[WidgetOption("icon", null)]
		public MobileIcon Icon { get; set; }
	}
}
