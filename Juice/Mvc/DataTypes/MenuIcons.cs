using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mvc {

	/// <summary>
	/// Defines the icons to diaplay for the MenuWidget.
	/// </summary>
	/// <remarks>Inheriting from Dictionary for serialization ease.</remarks>
	public class MenuIcons : Dictionary<String, String> {

		public MenuIcons() : base() {
			this.Add("submenu", "ui-icon-circle-triangle-e");
		}

		private new void Add(String key, String value){
			base.Add(key, value);
		}

		private new void Remove(String key) {
			base.Remove(key);
		}

		/// <summary>
		/// The icon displayed on menu items with submenus.
		/// </summary>
		public String Submenu {
			get { return this["submenu"]; }
			set { this["submenu"] = value; }
		}

	}
}
