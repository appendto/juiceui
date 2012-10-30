using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mvc {

	/// <summary>
	/// Defines the options for positing a widget.
	/// </summary>
	/// <remarks>Inheriting from Dictionary for serialization ease.</remarks>
	public class PositionOptions : Dictionary<String, String> {

		public PositionOptions() : base() {
			this.Add("my", "left top");
			this.Add("at", "right top");
			this.Add("of", null);
			this.Add("collision", null);
			this.Add("using", null);
			this.Add("within", null);
		}

		private new void Add(String key, String value){
			base.Add(key, value);
		}

		private new void Remove(String key) {
			base.Remove(key);
		}

		public String My {
			get { return this["my"]; }
			set { this["my"] = value; }
		}

		public String At {
			get { return this["at"]; }
			set { this["at"] = value; }
		}

		public String Of {
			get { return this["of"]; }
			set { this["of"] = value; }
		}

		public String Collision {
			get { return this["collision"]; }
			set { this["collision"] = value; }
		}

		public String Using {
			get { return this["using"]; }
			set { this["using"] = value; }
		}

		public String Within {
			get { return this["within"]; }
			set { this["within"] = value; }
		}

	}
}
