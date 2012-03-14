using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile {

	//Radio button
	//Pairs of labels and inputs with type="radio" are auto-enhanced, no data-role required
	[TargetControlType(typeof(RadioButton))]
	[TargetControlType(typeof(HtmlInputRadioButton))]
	public class RadioButton : Juice.Mobile.Framework.MobileExtender {


	}
}
