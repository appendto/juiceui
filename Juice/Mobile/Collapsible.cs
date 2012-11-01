using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {

	//A heading and content wrapped in a container with the data-role="collapsible"
	[ParseChildren(false)]
	public class Collapsible : ThemeControlBase {

		public Collapsible() : base("collapsible") {

		}
		
		/// <summary>
		/// When false, the container is initially expanded with a minus icon in the header.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("collapsed", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("When false, the container is initially expanded with a minus icon in the header.")]
		public Boolean Collapsed { get; set; }

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
	}
}
