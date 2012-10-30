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
	/// Links with data-role="button". Input-based buttons and button elements are auto-enhanced, no data-role required
	/// </summary>
	[TargetControlType(typeof(HtmlGenericControl))]
	[TargetControlType(typeof(HtmlAnchor))]
	[TargetControlType(typeof(HtmlButton))]
	[TargetControlType(typeof(HtmlInputButton))]
	[TargetControlType(typeof(Button))]
	[TargetControlType(typeof(LinkButton))]
	public class Button : LinkBase
	{
		/// <summary>
		/// Applies the theme button border-radius if set to true. This option is also exposed as a data attribute: data-corners="false".
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Description("Whether to show corners or not.")]
		[WidgetOption("corners", true)]
		public Boolean Corners { get; set; }

		/// <summary>
		/// Applies an icon from the icon set. This option is also exposed as a data attribute: data-icon="star".
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[DefaultValue(null)]
		[Category("Appearance")]
		[Description("What type of icon to show for this button.")]
		[WidgetOption("icon", null)]
		public MobileIcon? Icon { get; set; }

		/// <summary>
		/// Positions the icon in the button. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback. This option is also exposed as a data attribute: data-iconpos="left"
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[DefaultValue(null)]
		[Category("Appearance")]
		[Description("Where to position the icon on the button. ")]
		[WidgetOption("iconpos", null)]
		public MobileIconPosition? IconPosition { get; set; }

		/// <summary>
		/// Whether or not to show an icon shadow.
		/// </summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Description("Whether or not to show an icon shadow.")]
		[WidgetOption("iconshadow", true)]
		public Boolean IconShadow { get; set; }

		//data-shadow	true | false
		/// <summary>
		/// Whether or not to show a button shadow.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Description("Whether or not to show a button shadow.")]
		[WidgetOption("shadow", true)]
		public Boolean Shadow { get; set; }
	}
}
