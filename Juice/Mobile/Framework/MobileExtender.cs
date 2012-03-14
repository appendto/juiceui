using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile.Framework {
	public class MobileExtender : ExtenderControl {

		private Control _targetControl;

		public MobileExtender() : this(null) { }

		public MobileExtender(String role) {
			this.Role = role;
			this.ClientIDMode = ClientIDMode.Static;
		}

		internal Control TargetControl { get; private set; }

		//data-mini	true | false - Compact sized version
		[WidgetOption("mini", false)]
		public Boolean Mini { get; set; }

		[WidgetOption("role", null)]
		public String Role { get; protected set; }

		//data-theme	swatch letter (a-z)
		[WidgetOption("theme", null)]
		public String Theme { get; set; }

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			_targetControl = FindControl(TargetControlID);

			if(_targetControl == null) {
				throw new ArgumentNullException("TargetControl is null");
			}

			this.TargetControl = _targetControl;
		}

		protected override void OnPreRender(EventArgs e) {
			
			// TODO: parse the options, compare to the default, add attributes if necessary.
			
			base.OnPreRender(e);
		}

		protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl) {
			return null;
		}

		protected override IEnumerable<ScriptReference> GetScriptReferences() {
			return null;
		}
	}
}
