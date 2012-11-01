using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mvc {

	/// <summary>
	/// Defines the icons to diaplay for the AccordionWidget.
	/// </summary>
	/// <remarks>Inheriting from Dictionary for serialization ease.</remarks>
	public class AccordionIcons : Dictionary<String, String> {

		public AccordionIcons() : base() {
			this.Add("header", String.Empty);
			this.Add("activeHeader", String.Empty);
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
		public String Header {
			get { return this["header"]; }
			set { this["header"] = value; }
		}

		/// <summary>
		/// The icon displayed on the right of the button.
		/// </summary>
		public String ActiveHeader {
			get { return this["activeHeader"]; }
			set { this["activeHeader"] = value; }
		}
	}
}
