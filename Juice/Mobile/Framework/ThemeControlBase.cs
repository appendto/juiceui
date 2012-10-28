using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Juice.Framework;

namespace Juice.Mobile {
	public class ThemeControlBase : Juice.Mobile.Framework.MobileControlBase {

		public ThemeControlBase(String role) : base(role) { }

		//data-theme	swatch letter (a-z)
		[WidgetOption("theme", null)]
		public String Theme { get; set; }

	}
}
