using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Juice.Mobile {
	public class FlipToggleItem : HtmlSelect {

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.Option; } }

		public String Value {
			get { return this.Attributes["value"] as String ?? String.Empty; }
			set { this.Attributes["value"] = value; }
		}

		public String Selected {
			get { return this.Attributes["selected"] as String ?? String.Empty; }
			set {
				if(String.IsNullOrEmpty(value)) {
					this.Attributes.Remove("selected");
				}
				else {
					this.Attributes["selected"] = value;
				}
			}
		}
	}
}
