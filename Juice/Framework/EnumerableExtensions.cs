using System;
using System.Collections.Generic;
using System.Linq;

namespace Juice.Framework {

	public static class EnumerableExtensions {

		/// <summary>
		/// Compares two enumberable collections to determine if their contained values are equal.
		/// </summary>
		public static bool ItemsAreEqual<T>(this IEnumerable<T> source, IEnumerable<T> second) {
			return source.OrderBy(a => a).SequenceEqual(second.OrderBy(a => a));
		}
	}
}