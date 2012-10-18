using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {

	public abstract class LinkBase : Juice.Mobile.Framework.MobileExtender {

		//data-ajax	true | false
		[WidgetOption("ajax", true)]
		public Boolean Ajax { get; set; }

		//data-direction	reverse (reverse page transition animation)
		[WidgetOption("direction", null)]
		public MobileDirection Direction { get; set; }

		//data-dom-cache	true | false
		[WidgetOption("dom-cache", false)]
		public Boolean DomCache { get; set; }

		//data-prefetch	true | false
		[WidgetOption("prefetch", false)]
		public Boolean Prefetch { get; set; }

		//data-rel	back (to move one step back in history) | dialog
		[WidgetOption("rel", null)]
		public MobileRel Relationship { get; set; }

		//data-transition	slide | slideup | slidedown | pop | fade | flip
		[WidgetOption("transition", "slide")]
		public MobileTransition Transition { get; set; }
	}
}
