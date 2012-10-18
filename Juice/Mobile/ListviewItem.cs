using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {
	
	//LI within a listview
	[ParseChildren(false)]
	public class ListviewItem : ThemeControlBase {

		public ListviewItem() : base(null) { }

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.Li; } }

		public Boolean Divider {
			get { return this.Role == "list-divider"; }
			set { this.Role = value ? "list-divider" : null;  }
		}

		//data-filtertext	string (filter by this value instead of inner text)
		[WidgetOption("filtertext", null)]
		public String FilterText { get; set; }

		//data-icon	home | delete | plus | arrow-u | arrow-d | check | gear | grid | star | custom | arrow-r | arrow-l | minus | refresh | forward | back | alert | info | search
		[WidgetOption("icon", null)]
		public MobileIcon? Icon { get; set; }
	}
}
