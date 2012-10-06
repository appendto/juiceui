using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Juice;

namespace WebForms {
	public partial class Autocomplete : System.Web.UI.Page {

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			_Autocomplete.SourceList = new List<Juice.AutocompleteItem>() {
				new AutocompleteItem { Label = "1", Value = "2" },
				new AutocompleteItem { Label = "3", Value = "4" }
			};

			_Button.Click += delegate(object sender, EventArgs ea) {
				object o = this._Autocomplete.Widget_Source;
			};
		}

	}
}