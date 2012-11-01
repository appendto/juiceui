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
	public class Popup : ThemeControlBase {

		public Popup() : base("popup") { }
		
		//data-corners	true | false
		/// <summary>
		/// Sets whether to draw the popup with rounded corners.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("corners", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Sets whether to draw the popup with rounded corners.")]
		public Boolean Corners { get; set; }

		/// <summary>
		/// Allow popup to be closed.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("dismissable", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Allow popup to be closed.")]
		public Boolean Dismissable { get; set; }

		//data-overlay-theme	swatch letter (a-z) - overlay theme when the page is opened in a dialog
		/// <summary>
		/// Sets the color scheme (swatch) for the popup background, which covers the entire window.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("overlay-theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Sets the color scheme (swatch) for the popup background, which covers the entire window.")]
		public String OverlayTheme { get; set; }

		/// <summary>
		/// Sets whether to draw a shadow around the popup.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("shadow", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Sets whether to draw a shadow around the popup.")]
		public Boolean Shadow { get; set; }

		/// <summary>
		/// Sets the minimum distance from the edge of the window for the corresponding edge of the popup. By default, the values above will be used for the distance from the top, right, bottom, and left edge of the window, respectively.
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("tolerance", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Sets the minimum distance from the edge of the window for the corresponding edge of the popup. By default, the values above will be used for the distance from the top, right, bottom, and left edge of the window, respectively.")]
		[TypeConverter(typeof(Juice.Mobile.Framework.TypeConverters.MobileToleranceConverter))]
		public Juice.Mobile.MobileTolerance Tolerance { get; set; }
	}
}
