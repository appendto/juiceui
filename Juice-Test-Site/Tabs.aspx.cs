using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Juice_Sample_Site {
  public partial class Tabs : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
			_Tabs.SelectedTabChanged += _Tabs_Change;
			_Post.Click += delegate(object s, EventArgs ea) {
				var i = 0;
			};
    }

		protected void _Tabs_Change(object sender, EventArgs e) {
			var j = 0;
		}
  }
}