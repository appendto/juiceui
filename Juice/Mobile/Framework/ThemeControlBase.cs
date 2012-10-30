using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {
	public class ThemeControlBase : Juice.Mobile.Framework.MobileControlBase {

		public ThemeControlBase(String role) : base(role) { }

		//data-theme	swatch letter (a-z)
		/// <summary>
		/// Defines the theme swatch letter (a-z)
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Defines the theme swatch letter (a-z)")]
		public String Theme { get; set; }

	}
}
