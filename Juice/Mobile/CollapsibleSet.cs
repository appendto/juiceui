using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {

	//A number of collapsibles wrapped in a container with the data-role="collapsible-set"
	/// <summary>
	/// A number of collapsibles wrapped in a container with the data-role="collapsible-set".
	/// </summary>
	[ParseChildren(false)]
	public class CollapsibleSet : ThemeControlBase {

		public CollapsibleSet() : base("collapsible-set") { }

		/// <summary>
		/// Sets the color scheme (swatch) for the collapsible content block. It accepts a single letter from a-z that maps to one of the swatches included in your theme.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("content-theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Sets the color scheme (swatch) for the collapsible content block. It accepts a single letter from a-z that maps to one of the swatches included in your theme.")]
		public String ContentTheme { get; set; }

		/// <summary>
		/// Sets the size of the element to a more compact, mini version.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("mini", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Sets the size of the element to a more compact, mini version.")]
		public Boolean Mini { get; set; }

		/// <summary>
		/// By setting this option to false the collapsibles will get a full width appearance without corners.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("inset", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("By setting this option to false the collapsibles will get a full width appearance without corners.")]
		public Boolean Inset { get; set; }
	}
}
