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
	/// Pairs of labels and inputs with type="checkbox" are auto-enhanced, no data-role required
	/// </summary>
	[TargetControlType(typeof(CheckBox))]
	[TargetControlType(typeof(HtmlInputCheckBox))]
	public class Checkbox : Juice.Mobile.Framework.MobileExtender
	{

	}
}
