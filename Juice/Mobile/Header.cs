using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Juice.Framework;

namespace Juice.Mobile {

	/// <summary>
	/// Container with data-role="header".
	/// </summary>
	[ParseChildren(false)]
	public class Header : ThemeControlBase {

		public Header() : base("header") { }

		/// <summary>
		/// Where to position the footer. Accepts fixed.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("position", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Where to position the footer. Accepts fixed.")]
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
