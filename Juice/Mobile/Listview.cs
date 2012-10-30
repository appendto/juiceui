using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {
	
	/// <summary>
	/// OL or UL with data-role="listview".
	/// </summary>
	[ParseChildren(false)]	
	public class Listview : ThemeControlBase {

		private HtmlTextWriterTag _tag = HtmlTextWriterTag.Ul;

		public Listview() : base("listview"){}
		
		protected override HtmlTextWriterTag TagKey { get { return _tag; } }

		public Boolean NumberedList {
			get {
				return _tag == HtmlTextWriterTag.Ol;
			}
			set {
				_tag = value ? _tag = HtmlTextWriterTag.Ol : _tag = HtmlTextWriterTag.Ul;
			}
		}

		/// <summary>
		/// Sets the color scheme (swatch) for list item count bubbles.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("count-theme", "c")]
		[Category("Appearance")]
		[DefaultValue("c")]
		[Description("Sets the color scheme (swatch) for list item count bubbles.")]
		public String CountTheme { get; set; }

		/// <summary>
		/// Sets the color scheme (swatch) for list dividers.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("dividertheme", "b")]
		[Category("Appearance")]
		[DefaultValue("b")]
		[Description("Sets the color scheme (swatch) for list dividers.")]
		public String DividerTheme { get; set; }

		/// <summary>
		/// Adds a search filter bar to listviews.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("filter", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Adds a search filter bar to listviews.")]
		public Boolean Filter { get; set; }

		/// <summary>
		/// The placeholder text used in search filter bars.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("filter-placeholder", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Adds a search filter bar to listviews.")]
		public String FilterPlaceholder { get; set; }

		/// <summary>
		/// Sets the color scheme (swatch) for the search filter bar.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("filter-theme", "c")]
		[Category("Appearance")]
		[DefaultValue("c")]
		[Description("Sets the color scheme (swatch) for the search filter bar.")]
		public String FilterTheme { get; set; }

		/// <summary>
		/// Adds inset list styles.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("inset", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Adds inset list styles.")]
		public Boolean Inset { get; set; }

		/// <summary>
		/// Applies an icon from the icon set to all split list buttons.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("split-icon", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Applies an icon from the icon set to all split list buttons.")]
		public MobileIcon? SplitIcon { get; set; }

		/// <summary>
		/// Sets the color scheme (swatch) for split list buttons.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("split-theme", "b")]
		[Category("Appearance")]
		[DefaultValue("b")]
		[Description("Sets the color scheme (swatch) for split list buttons.")]
		public String SplitTheme { get; set; }
	}
}
