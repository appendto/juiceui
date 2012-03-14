using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {
	
	// TODO: ListviewItem

	//OL or UL with data-role="listview"
	public class Listview : ThemeControlBase {

		public Listview() : base("listview"){}

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.Ul; } }

		//data-count-theme	swatch letter (a-z)
		[WidgetOption("count-theme", null)]
		public String CountTheme { get; set; }
		
		//data-dividertheme	swatch letter (a-z)
		[WidgetOption("dividertheme", null)]
		public String DividerTheme { get; set; }
		
		//data-filter	true | false
		[WidgetOption("filter", false)]
		public Boolean Filter { get; set; }
		
		//data-filter-placeholder	string
		[WidgetOption("filter-placeholder", null)]
		public String FilterPlaceholder { get; set; }
		
		//data-filter-theme	swatch letter (a-z)
		[WidgetOption("filter-theme", null)]
		public String FilterTheme { get; set; }

		//data-inset	true | false
		[WidgetOption("inset", false)]
		public Boolean Inset { get; set; }
		
		//data-split-icon	home | delete | plus | arrow-u | arrow-d | check | gear | grid | star | custom | arrow-r | arrow-l | minus | refresh | forward | back | alert | info | search
		[WidgetOption("split-icon", null)]
		public MobileIcon SplitIcon { get; set; }

		//data-split-theme	swatch letter (a-z)	
		[WidgetOption("split-theme", null)]
		public String SplitTheme { get; set; }

	}
}
