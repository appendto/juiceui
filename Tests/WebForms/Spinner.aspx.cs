using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms {

	public partial class Spinner : System.Web.UI.Page {
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			_TextSpinner.ValueChanged += foo;
			_InputSpinner.ValueChanged += bar;

			_Button.Click += delegate(object sender, EventArgs ea) {
				object o = 5;
			};
		}

		void foo(object sender, EventArgs ea) {
			string f = "";

			f = _Text.Text;
			
		}

		void bar(object sender, EventArgs ea) {
			string f = "";

			f = _Text.Text;

		}
	}
}