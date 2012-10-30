using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mvc {

	/// <summary>
	/// Defines the buttons to add to a DialogWidget.
	/// </summary>
	/// <remarks>Inheriting from Dictionary for serialization ease.</remarks>
	public class ShowOptions : Dictionary<String, String> {

		/// <summary>
		/// Adds an option to the collection.
		/// </summary>
		/// <param name="optionName">The name of the showOption to add.</param>
		/// <param name="optionValue">The value of the showOption to add.</param>
		private new void Add(String optionName, String optionValue){
			base.Add(optionName, optionValue);
		}
	}
}
