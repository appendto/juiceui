using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Juice.Mobile.Framework {
	public abstract class MobileControlBase : ScriptControl, IMobileControl {

		private MobileBridge _bridge;

		public MobileControlBase(String role) {
			this.Role = role;
			this.ClientIDMode = ClientIDMode.Static;

			_bridge = new MobileBridge(this);
		}

		protected override HtmlTextWriterTag TagKey { get { return HtmlTextWriterTag.Div; } }

		public Control TargetControl { get { return this; } }

		public String Role { get; protected set; }

		protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors() {
			return null;
		}

		protected override IEnumerable<ScriptReference> GetScriptReferences() {
			return _bridge.GetScriptReferences();
		}
	}
}
