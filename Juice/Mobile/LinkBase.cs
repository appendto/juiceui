using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {

	public abstract class LinkBase : Juice.Mobile.Framework.MobileExtender {

		public LinkBase() : base("button") { }

		/// <summary>
		/// Use ajax to retrieve this link.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("ajax", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Use ajax to retrieve this link.")]
		public Boolean Ajax { get; set; }

		/// <summary>
		/// Reverse page transition animation.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("direction", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Reverse page transition animation.")]
		public MobileDirection? Direction { get; set; }

		/// <summary>
		/// Apply dom-cache.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("dom-cache", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Apply dom-cache.")]
		public Boolean DomCache { get; set; }

		/// <summary>
		/// Inline link.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("inline", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Inline link.")]
		public Boolean Inline { get; set; }
		
		/// <summary>
		/// When using single-page templates, you can prefetch pages into the DOM so that they're available instantly when the user visits them.
		/// </summary>
		[WidgetOption("prefetch", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("When using single-page templates, you can prefetch pages into the DOM so that they're available instantly when the user visits them.")]
		public Boolean Prefetch { get; set; }

		/// <summary>
		/// How the link should behave, Back, Dialog, External, or Popup.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("rel", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("How the link should behave, Back, Dialog, External, or Popup.")]
		public MobileRel? Relationship { get; set; }

		/// <summary>
		/// By default, the dialog will open with a 'pop' transition.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("transition", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("By default, the dialog will open with a 'pop' transition.")]
		public MobileTransition? Transition { get; set; }
	}
}
