using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mvc {

	/// <summary>
	/// Defines the icons to diaplay for the ButtonWidget.
	/// </summary>
	/// <remarks>Inheriting from Dictionary for serialization ease.</remarks>
	public class CursorAt : Dictionary<String, int?> {

		public CursorAt() : base() {
			this.Add("top", null);
			this.Add("left", null);
			this.Add("bottom", null);
			this.Add("right", null);
		}

		private new void Add(String key, int? value){
			base.Add(key, value);
		}

		private new void Remove(String key) {
			base.Remove(key);
		}

		public int? Top {
			get { return this["top"]; }
			set { this["top"] = value; }
		}

		public int? Left {
			get { return this["left"]; }
			set { this["left"] = value; }
		}

		public int? Bottom {
			get { return this["bottom"]; }
			set { this["bottom"] = value; }
		}

		public int? Right {
			get { return this["right"]; }
			set { this["right"] = value; }
		}

	}
}
