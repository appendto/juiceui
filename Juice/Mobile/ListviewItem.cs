using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {
	
	/// <summary>
	/// LI within a listview.
	/// </summary>
	[ParseChildren(false)]
	public class ListviewItem : ThemeControlBase {

		public ListviewItem() : base(null) { }

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.Li; } }

		public Boolean Divider {
			get { return this.Role == "list-divider"; }
			set { this.Role = value ? "list-divider" : null;  }
		}

		/// <summary>
		/// Filter by this value instead of inner text.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("filtertext", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Filter by this value instead of inner text.")]
		public String FilterText { get; set; }

		/// <summary>
		/// The icon for this item.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("icon", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("The icon for this item.")]
		public MobileIcon? Icon { get; set; }
	}
}
