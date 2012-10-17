using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace WebForms {
	public partial class Base : System.Web.UI.MasterPage {
		protected void Page_Load(object sender, EventArgs e) {

			//CssManager.CssResourceMapping.AddDefinition("juice-ui", new CssResourceDefinition {
			//  Path = "~/css/ui-lightness/jquery-ui-1.9.0pre.custom.css",
			//  DebugPath = "~/css/ui-lightness/jquery-ui-1.9.0pre.custom.css"
			//});

		}
	}
}