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

		/// <summary>
		/// The icon to display when the collapsible is collapsed.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("collapsed-icon", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Applies an icon from the icon set.")]
		public MobileIcon? CollapsedIcon { get; set; }

		/// <summary>
		/// The icon to display when the collapsible is expanded.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("expanded-icon", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Applies an icon from the icon set.")]
		public MobileIcon? ExpandedIcon { get; set; }

		/// <summary>
		/// Positions the icon in the button. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("iconpos", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Positions the icon in the button. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.")]
		public MobileIconPosition? IconPosition { get; set; }

		/// <summary>
		/// Determines whether or not the collapsibles has an inset appearance.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("inset", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Determines whether or not the collapsibles has an inset appearance.")]
		public Boolean Inset { get; set; }
	}
}
