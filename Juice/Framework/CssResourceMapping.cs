using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;

namespace Juice.Framework {
	public class CssResourceMapping : ScriptResourceMapping {

		public void AddDefinition(string name, CssResourceDefinition definition) {
			if(String.IsNullOrEmpty(definition.Path)) {
				throw new ArgumentException("CssResourceDefintion.Path doesn't contain valid URL.");
			}
			
			base.AddDefinition(name, definition);
		}

		public new void AddDefinition(string name, Assembly assembly, CssResourceDefinition definition) {
			throw new NotImplementedException();
		}

		public new CssResourceDefinition GetDefinition(string name) {
			return base.GetDefinition(name, null) as CssResourceDefinition;
		}

		public new CssResourceDefinition GetDefinition(ScriptReference scriptReference) {
			throw new NotImplementedException();
		}

		public new CssResourceDefinition GetDefinition(string name, Assembly assembly) {
			throw new NotImplementedException();
		}
	}
}
