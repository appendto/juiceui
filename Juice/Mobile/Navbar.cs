using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {

	/// <summary>
	/// A number of LIs wrapped in a container with data-role="navbar".
	/// </summary>
	[ParseChildren(typeof(NavbarItem))]
	public class Navbar : ThemeControlBase {

		public Navbar() : base("navbar") { }

		/// <summary>
		/// Icon navbar.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("icon", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Icon navbar.")]
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

		protected override void Render(HtmlTextWriter writer) {

			this.RenderBeginTag(writer);

			writer.RenderBeginTag(HtmlTextWriterTag.Ul);

			this.RenderChildren(writer);

			writer.RenderEndTag();

			this.RenderEndTag(writer);
		}
	}
}
