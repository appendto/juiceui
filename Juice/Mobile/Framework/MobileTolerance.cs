using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Juice.Mobile.Framework {

	[TypeConverter(typeof(TypeConverters.MobileToleranceConverter))]
	public class MobileTolerance {

		public MobileTolerance() { }

		public MobileTolerance(int top, int right, int bottom, int left) {
			Top = top;
			Right = right;
			Bottom = bottom;
			Left = left;
		}

		public int Top { get; set; }
		public int Right { get; set; }
		public int Bottom { get; set; }
		public int Left { get; set; }

		public override string ToString() {
			return String.Join(",", Top, Right, Bottom, Left);
		}
	}
}
