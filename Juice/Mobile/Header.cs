using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Juice.Framework;

namespace Juice.Mobile {

	//Container with data-role="header"
	[ParseChildren(false)]
	public class Header : ThemeControlBase {

		public Header() : base("header") { }

		//data-position	fixed
		[WidgetOption("position", null)]
		public MobilePosition Position { get; set; }

		public String Text { get; set; }

		protected override void OnPreRender(EventArgs e) {

			if(!String.IsNullOrEmpty(this.Text)) {
				this.Controls.AddAt(0, new HtmlGenericControl("h1") { InnerHtml = this.Text });
			}

			base.OnPreRender(e);
		}
	}
}
