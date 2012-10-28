using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Juice.Mobile {

	[PersistChildren(false)]
	[ParseChildren(true, "Text")]
	public class FlipToggleItem : HtmlGenericControl {

		public FlipToggleItem() : base(System.Web.UI.HtmlTextWriterTag.Option.ToString()) { }

		public FlipToggleItem(String tag) : base(System.Web.UI.HtmlTextWriterTag.Option.ToString()) { }

		public String Text { get { return this.InnerHtml; } set { this.InnerHtml = value; } }

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
