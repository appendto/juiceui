using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Juice.Mobile {

	[TargetControlType(typeof(HtmlAnchor))]
	[TargetControlType(typeof(LinkButton))]
	public class Link : LinkBase {

	}
}
