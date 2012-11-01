using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mvc {

	/// <summary>
	/// Defines the buttons to add to a DialogWidget.
	/// </summary>
	/// <remarks>Inheriting from Dictionary for serialization ease.</remarks>
	public class ButtonList : Dictionary<String, String> {

		/// <summary>
		/// Adds a button to the list.
		/// </summary>
		/// <param name="buttonText">The text that the button will display.</param>
		/// <param name="functionName">The name of the Javascript function to execute when the button is clicked.</param>
		private new void Add(String buttonText, String functionName){
			base.Add(buttonText, functionName);
		}
	}
}
