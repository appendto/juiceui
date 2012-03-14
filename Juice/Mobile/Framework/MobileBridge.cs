using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile.Framework {
	public class MobileBridge {

		private Control _bridgeTo;
		private CssManager _cssManager;

		public MobileBridge(Control bridgeTo) {

			_bridgeTo = bridgeTo;
			_cssManager = new CssManager(bridgeTo);

			_bridgeTo.PreRender += delegate(object sender, EventArgs e) { this.PreRender(); };
			_bridgeTo.Load += delegate(object sender, EventArgs e) {
				_bridgeTo.Page.Unload += delegate(object s, EventArgs ea) { this.RenderMeta(); };
			};

			this.SetDefaults();
		}

		public Boolean MetaViewPortExists {
			get { 
				Boolean? value = _bridgeTo.Page.Items["MobileBridge.MetaViewPortExists"] as Boolean?;
				return value == null ? false : value.Value;
			}
			set { _bridgeTo.Page.Items["MobileBridge.MetaViewPortExists"] = value; }
		}

		private void RenderCss() {
			_cssManager.Render(new List<String> {
				"jquery-mobile"
			});
		}

		private void RenderMeta() {
			
			if(this.MetaViewPortExists) {
				return;
			}

			HtmlHead header = _bridgeTo.Page.Header;
			List<Control> controls = header.Controls.All().ToList();
			HtmlMeta viewport = controls.OfType<HtmlMeta>().Where(m => m.Name != null && m.Name.ToLower() == "viewport").FirstOrDefault();

			if(viewport != null) {
				this.MetaViewPortExists = true;
				return;
			}

			viewport = new HtmlMeta {
				Name = "viewport",
				Content = "width=device-width, initial-scale=1"
			};

			header.Controls.Add(viewport);

			this.MetaViewPortExists = true;
		}

		private void SetDefaults() {

			var options = (from property in TypeDescriptor.GetProperties(_bridgeTo).OfType<PropertyDescriptor>()
										 let attribute = property.Attributes.OfType<WidgetOptionAttribute>().SingleOrDefault()
										 where attribute != null
										 select new { Option = attribute, Property = property }).ToList();

			foreach(var o in options) {
				object @default = o.Option.DefaultValue;
				object current = o.Property.GetValue(_bridgeTo);

				if(@default != current) {
					o.Property.SetValue(_bridgeTo, @default);
				}
			}
		}

		public IEnumerable<ScriptReference> GetScriptReferences() {
			return new List<ScriptReference> {
				new ScriptReference("jquery", null),
				new ScriptReference("jquery-ui", null),
				new ScriptReference("jquery-mobile", null)
			};
		}

		internal void PreRender() {

			if(!_bridgeTo.Visible) {
				return;
			}

			this.RenderCss();
			this.RenderMeta();

			IMobileControl control = _bridgeTo as IMobileControl;
			IAttributeAccessor attributes = _bridgeTo as IAttributeAccessor;

			if(control.Role != null) {
				attributes.SetAttribute("data-role", control.Role);
			}

			var options = (from property in TypeDescriptor.GetProperties(_bridgeTo).OfType<PropertyDescriptor>()
										 let attribute = property.Attributes.OfType<WidgetOptionAttribute>().SingleOrDefault()
										 where attribute != null
										 select new { Option = attribute, Property = property }).ToList();

			// at the moment, there aren't any jQuery Mobile options which accept an array. if this changes, we need to test arrays here.

			foreach(var o in options) {

				object current = o.Property.GetValue(_bridgeTo);

				if((current == null && o.Option.DefaultValue != null) || (current != null && !current.Equals(o.Option.DefaultValue))) {
					attributes.SetAttribute(String.Concat("data-", o.Option.Name), current.ToString().ToLower());
				}
			}

		}

	}
}
