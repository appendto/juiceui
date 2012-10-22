using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {
	
	//Select with data-role="slider", two options only
	[ParseChildren(typeof(FlipToggleItem))]
	public class FlipToggle : ThemeControlBase {

		public FlipToggle() : base("slider") { }

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.Select; } }

		//data-mini	true | false - Compact sized version
		[WidgetOption("mini", false)]
		public Boolean Mini { get; set; }

		//data-track-theme	swatch letter (a-z) - Added to the form element
		[WidgetOption("track-theme", null)]
		public String TrackTheme { get; set; }

		//data-role	none (prevents auto-enhancement to use native control)
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
