using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mvc {

	/// <summary>
	/// Defines the icons to diaplay for the ButtonWidget.
	/// </summary>
	/// <remarks>Inheriting from Dictionary for serialization ease.</remarks>
	public class ButtonIcons : Dictionary<String, String> {

		public ButtonIcons() : base() {
			this.Add("primary", String.Empty);
			this.Add("secondary", String.Empty);
		}

		private new void Add(String key, String value){
			base.Add(key, value);
		}

		private new void Remove(String key) {
			base.Remove(key);
		}

		/// <summary>
		/// The icon displayed on the left of the button.
		/// </summary>
		public String Primary {
			get { return this["primary"]; }
			set { this["primary"] = value; }
		}

		/// <summary>
		/// The icon displayed on the right of the button.
		/// </summary>
		public String Secondary {
			get { return this["secondary"]; }
			set { this["secondary"] = value; }
		}
	}
}
