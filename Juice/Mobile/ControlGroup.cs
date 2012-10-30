using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {

	/// <summary>
	/// Multiple selects/buttons can be wrapped in a fieldset with a data-role="controlgroup" attribute for a vertically grouped set. 
	/// </summary>
	[ParseChildren(false)]
	public class ControlGroup : Juice.Mobile.Framework.MobileControlBase {

		public ControlGroup() : base("controlgroup") { }

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.Fieldset; } }

		/// <summary>
		/// Add the data-type="horizontal" attribute for the selects to sit side-by-side.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("type", null)]
		[Category("Data")]
		[DefaultValue(null)]
		[Description("Add the data-type=\"horizontal\" attribute for the selects to sit side-by-side.")]
		public MobileGroupType? GroupType { get; set; }
	}
}
