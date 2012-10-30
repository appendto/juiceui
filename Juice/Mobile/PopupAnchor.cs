using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		/// <summary>
		/// Centers the popup over the link that opens it, or the specific element.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("position-to", "origin")]
		[Category("Behavior")]
		[DefaultValue("origin")]
		[Description("Centers the popup over the link that opens it, or the specific element.")]
		public String PositionTo { get; set; }

		/// <summary>
		/// Defines the behavior of the Anchor.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("rel", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Defines the behavior of the Anchor.")]
		public new MobileRel? Relationship { get { return MobileRel.Popup; } }

	}
}
