using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Juice {

	/// <summary>
	/// Extend a TextBox with the jQuery UI Buttonset http://api.jqueryui.com/button/
	/// </summary>
	/// <remarks>Click Events should be handled on the extended control, natively.</remarks>
	public class Buttonset : Button {

		public Buttonset() : base("buttonset") { }

	}
}