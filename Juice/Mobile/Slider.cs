using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile {

	//Inputs with type="range" are auto-enhanced, no data-role required
	[TargetControlType(typeof(HtmlInputControl))]
	public class Slider : Juice.Mobile.Framework.MobileExtender {

		//data-highlight	true | false - Adds an active state fill on track to handle
		[WidgetOption("highlight", false)]
		public Boolean Highlight { get; set; }

		//data-track-theme	swatch letter (a-z) - Added to the form element
		[WidgetOption("track-theme", null)]
		public String TrackTheme { get; set; }

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			var control = this.TargetControl as IAttributeAccessor;
			String type = control.GetAttribute("type") as String;

			if(String.IsNullOrEmpty(type) || type.ToLower() != "range") {
				throw new ArgumentException("Inputs extended by Juice.Mobile.Slider must have the attribute 'type=\"range\"'.");
			}
		}
	}
}
