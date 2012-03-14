using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Juice.Framework {

	public static class EnumerableExtensions {

		/// <summary>
		/// Compares two enumberable collections to determine if their contained values are equal.
		/// </summary>
		public static bool ItemsAreEqual<T>(this IEnumerable<T> source, IEnumerable<T> second) {
			return source.OrderBy(a => a).SequenceEqual(second.OrderBy(a => a));
		}

		/// <summary>
		/// Allows Linq operations on the controls collection.
		/// </summary>
		public static IEnumerable<Control> All(this ControlCollection controls) {
			foreach(Control control in controls) {
				foreach(Control grandChild in control.Controls.All()) {
					yield return grandChild;
				}

				yield return control;
			}
		}
	}
}