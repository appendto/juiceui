using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mvc {

	/// <summary>
	/// Defines the icons to diaplay for the SpinnerWidget. Icons to use for buttons, matching an icon defined by the jQuery UI CSS Framework.
	/// </summary>
	/// <remarks>Inheriting from Dictionary for serialization ease.</remarks>
	public class SpinnerIcons : Dictionary<String, String> {

		public SpinnerIcons() : base() {
			this.Add("down", "ui-icon-triangle-1-s");
			this.Add("up", "ui-icon-triangle-1-n");
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
		public String Down {
			get { return this["down"]; }
			set { this["down"] = value; }
		}

		/// <summary>
		/// The icon displayed on the right of the button.
		/// </summary>
		public String Up {
			get { return this["up"]; }
			set { this["up"] = value; }
		}
	}
}
