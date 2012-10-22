using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {

	//Multiple selects/buttons can be wrapped in a fieldset with a data-role="controlgroup" attribute for a vertically grouped set. 
	[ParseChildren(false)]
	public class ControlGroup : Juice.Mobile.Framework.MobileControlBase {

		public ControlGroup() : base("controlgroup") { }

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.Fieldset; } }

		//Add the data-type="horizontal" attribute for the selects to sit side-by-side.
		[WidgetOption("type", null)]
		public MobileGroupType? GroupType { get; set; }
	}
}
