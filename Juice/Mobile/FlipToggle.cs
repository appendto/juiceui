using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {
	
	/// <summary>
	/// A binary "flip" switch is a common UI element on mobile devices that is used for binary on/off or true/false data input. Select with data-role="slider", two options only.
	/// </summary>
	[ParseChildren(typeof(FlipToggleItem))]
	public class FlipToggle : ThemeControlBase {

		public FlipToggle() : base("slider") { }

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.Select; } }

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
		/// Sets the color scheme (swatch) for the slider's track, specifically. It accepts a single letter from a-z that maps to one of the swatches included in your theme.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("track-theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Sets the color scheme (swatch) for the slider's track, specifically. It accepts a single letter from a-z that maps to one of the swatches included in your theme.")]
		public String TrackTheme { get; set; }

		/// <summary>
		/// Prevents auto-enhancement to use native control
		/// </summary>
		public String Role {
			get { return base.Role; }
			set {
				if(value != null && value.ToLower() == "none") {
					base.Role = value;
				}
			}
		}

		protected override void OnPreRender(EventArgs e) {

			if(this.Controls.All().Where(c => c is FlipToggleItem).Count() > 2) {
				throw new IndexOutOfRangeException("The FlipToggle control may only have two FlipToggleItems.");
			}

			base.OnPreRender(e);
		}
	}
}
