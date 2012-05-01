using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Juice {
	
	// using the DataContract Serialization here as changing the parameter names to match Autocomplete's format
	// is immensely easier, and there aren't any conflicts with string values we need to worry about.

	[DataContract]
	public class AutocompleteItem {

		public AutocompleteItem() { }

		[DataMember(Name = "label")]
		public String Label { get; set; }

		[DataMember(Name = "value")]
		public String Value { get; set; }
	}
}
