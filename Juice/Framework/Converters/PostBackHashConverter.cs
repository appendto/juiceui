using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Juice.Framework {

	internal class PostBackHashConverter : JavaScriptConverter {
	
		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer) {
			if(type != typeof(PostBackHash) && type != typeof(List<PostBackHash>)) {
				return null;
			}

			PostBackHash hash = new PostBackHash();

			if(dictionary.ContainsKey("id")) {
				hash.ControlID = serializer.ConvertToType<String>(dictionary["id"]);
			}

			if(dictionary.ContainsKey("widgetName")) {
				hash.WidgetName = serializer.ConvertToType<String>(dictionary["widgetName"]);
			}

			if(dictionary.ContainsKey("options")) {
				hash.Options = serializer.ConvertToType<Dictionary<String, object>>(dictionary["options"]);
			}

			return hash;
		}

		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer) {
			throw new NotSupportedException();
		}

		public override IEnumerable<Type> SupportedTypes {
			get { return new[] { typeof(PostBackHash), typeof(List<PostBackHash>) }; }
		}
	}
}
