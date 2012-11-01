using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.WebPages;
using Juice.Mvc;

namespace Juice.Mvc.Mobile {
		
	public class JuiceMobileWidget<TWidget> : JuiceWidget<TWidget> where TWidget : JuiceMobileWidget<TWidget>, IDisposable {

		// mobile attributes contain illegal characters, so we're going to map them here to the param names we've auto-gen'd.
		protected Dictionary<String, String> _optionsMap = null;
		protected AttributeCollection _attributes = new AttributeCollection(new StateBag());

		public JuiceMobileWidget(HtmlHelper helper, String role) : base(helper, null) {
			this.Role = role;
		}

		public String Role { get; protected set; }

		public override void Render() {

			RenderStart();

			if(_content != null) {
				HelperResult res = _content(this as TWidget);
				_writer.Write(res.ToHtmlString());
			}
		}

		// the underlying mvc system enforces a guid if no id is specified. we don't need that in mobile.
		internal override void SetCoreOptions(string elementId, string target) {
			
			Boolean idEmpty = String.IsNullOrEmpty(elementId);
			
			base.SetCoreOptions(elementId, target);

			if(idEmpty){
				_elementId = null;
			}
		}

		public TWidget AddAttribute(String name, String value) {
			_attributes[name] = value;
			return this as TWidget;
		}

		public virtual void RenderAttributes() {
			if(!String.IsNullOrEmpty(_elementId)) {
				_writer.WriteAttribute("id", _elementId);
			}

			if(_attributes.Count > 0) {
				_attributes.Render(_writer);
			}

			if(!String.IsNullOrEmpty(this.Role)) {
				_writer.WriteAttribute("data-role", this.Role);
			}

			var js = new JavaScriptSerializer();
			var optionList = _options
												.Where(o => o.Value.EqualsDefault == false)
												.ToDictionary(k => k.Key, k => k.Value.Value);

			foreach(var o in optionList) {
				var attribute = String.Empty;

				if(_optionsMap != null) {
					if(!_optionsMap.TryGetValue(o.Key, out attribute)) {
						attribute = o.Key;
					}
				}

				String attributeValue = String.Empty;

				if(o.Value is String) {
					attributeValue = o.Value.ToString();
				}
				else {
					attributeValue = o.Value is Enum ? o.Value.ToString().ToLower() : js.Serialize(o.Value);
				}

				_writer.WriteAttribute("data-" + attribute, attributeValue);
			}			
		}

		public override void RenderStart() {

			_writer.WriteBeginTag(this.Tag.ToString().ToLower());

			RenderAttributes();
			
			_writer.Write(HtmlTextWriter.TagRightChar);

		}

		public override void RenderEnd() {
			RenderEnd(_writer);
		}

		public void RenderEnd(TextWriter writer) {
			var w = new HtmlTextWriter(writer);
			RenderEnd(w);
		}

		public void RenderEnd(HtmlTextWriter writer) {
			writer.WriteEndTag(this.Tag.ToString().ToLower());
		}

	}
}
