using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile {

	[TargetControlType(typeof(HtmlAnchor))]
	[TargetControlType(typeof(LinkButton))]
	public class PopupAnchor : Anchor {

		[WidgetOption("position-to", "origin")]
		public String PositionTo { get; set; }

		[WidgetOption("rel", null)]
		public new MobileRel? Relationship { get { return MobileRel.Popup; } }

	}
}
