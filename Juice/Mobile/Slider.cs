using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile {

	//Inputs with type="range" are auto-enhanced, no data-role required
	[TargetControlType(typeof(HtmlInputControl))]
	[TargetControlType(typeof(TextBox))]
	public class Slider : Juice.Mobile.Framework.MobileExtender {

		//data-highlight	true | false - Adds an active state fill on track to handle
		/// <summary>
		/// Adds an active state fill on track to handle
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("highlight", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Adds an active state fill on track to handle")]
		public Boolean Highlight { get; set; }

		//data-track-theme	swatch letter (a-z) - Added to the form element
		/// <summary>
		/// Added to the form element
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("track-theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Added to the form element")]
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
