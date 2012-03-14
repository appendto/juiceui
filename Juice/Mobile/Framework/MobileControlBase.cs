using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Juice.Mobile.Framework {
	public abstract class MobileControlBase : WebControl {

		public MobileControlBase(String role) {
			this.Role = role;
			this.ClientIDMode = ClientIDMode.Static;
		}

		protected override HtmlTextWriterTag TagKey { get { return HtmlTextWriterTag.Div; } }

		public String Role { get; protected set; }

		protected override void OnPreRender(EventArgs e) {

			if(this.Role != null) {
				this.Attributes["data-role"] = this.Role;
			}

			// TODO: parse the options, compare to the default, add attributes if necessary.
			
			base.OnPreRender(e);
		}
	}
}
