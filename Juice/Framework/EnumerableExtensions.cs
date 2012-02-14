using System;
using System.Collections.Generic;
using System.Linq;

namespace Juice.Framework {

	internal static class EnumerableExtensions {

		public static bool ItemsAreEqual<T>(this IEnumerable<T> source, IEnumerable<T> second) {
			return source.OrderBy(a => a).SequenceEqual(second.OrderBy(a => a));
		}
	}
}