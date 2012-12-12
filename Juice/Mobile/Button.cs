using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile
{

	/// <summary>
	/// Links with data-role="button". Input-based buttons and button elements are auto-enhanced, no data-role required.
	/// </summary>
	[TargetControlType(typeof(HtmlGenericControl))]
	[TargetControlType(typeof(HtmlAnchor))]
	[TargetControlType(typeof(HtmlButton))]
	[TargetControlType(typeof(HtmlInputButton))]
	[TargetControlType(typeof(System.Web.UI.WebControls.Button))]
	[TargetControlType(typeof(LinkButton))]
	public class Button : LinkBase
	{
		/// <summary>
		/// Applies the theme button border-radius if set to true.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("corners", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Applies the theme button border-radius if set to true.")]
		public Boolean Corners { get; set; }

		/// <summary>
		/// Applies an icon from the icon set.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("icon", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Applies an icon from the icon set.")]
		public MobileIcon? Icon { get; set; }

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
		/// Applies the theme shadow to the button's icon if set to true.
		/// </summary>
		[WidgetOption("iconshadow", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Applies the theme shadow to the button's icon if set to true.")]
		public Boolean IconShadow { get; set; }

		/// <summary>
		/// Applies the drop shadow style to the button if set to true.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("shadow", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Applies the drop shadow style to the button if set to true.")]
		public Boolean Shadow { get; set; }
	}
}
