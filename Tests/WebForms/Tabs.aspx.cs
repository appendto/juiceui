using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace WebForms {
  public partial class Tabs : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
			_Tabs.SelectedTabChanged += _Tabs_Change;
			_Button.Click += delegate(object s, EventArgs ea) {
				object o = _Tabs.AccessKey;
			};

			var x = _Tabs.TabPages[0].TemplateContainer.Controls.All().Where(c => c.ID == "_Textbox").FirstOrDefault();
			var y = _Tabs.TabPages[0].FindControl("_Textbox");
    }

		protected void _Tabs_Change(object sender, EventArgs e) {
			var j = 0;
		}
  }
}