using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Juice.Framework {

	internal class WidgetHashClientStateJavaScriptConverter : JavaScriptConverter {
	
		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer) {
			throw new NotSupportedException();
		}

		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer) {
			var result = new Dictionary<string, object>();
			var state = obj as WidgetHashClientState;
			result.Add("name", state.Name);
			if(!String.IsNullOrEmpty(state.PostBackEventReference)) {
				result.Add("handler", state.PostBackEventReference);
			}
			return result;
		}

		public override IEnumerable<Type> SupportedTypes {
			get { return new[] { typeof(WidgetHashClientState) }; }
		}
	}
}
