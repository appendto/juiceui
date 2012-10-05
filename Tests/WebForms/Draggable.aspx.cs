using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Juice_Sample_Site {
	public partial class Draggable : System.Web.UI.Page {
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			_Draggable.Stop += delegate(object sender, EventArgs ea) {
				int i = 0;
			};

			_Button.Click += delegate(object sender, EventArgs ea) {
				object o = this._Draggable.AddClasses;
			};
		}

	}
}