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
	
	//Input type="text|number|search|etc." or textarea elements are auto-enhanced, no data-role required
	[TargetControlType(typeof(HtmlInputText))]
	[TargetControlType(typeof(HtmlTextArea))]
	[TargetControlType(typeof(TextBox))]
	public class Textbox : Juice.Mobile.Framework.MobileExtender {

		//data-mini	true | false - Compact sized version
		/// <summary>
		/// Compact sized version
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("mini", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Compact sized version")]
		public Boolean Mini { get; set; }

	}
}
