using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice.Mobile.Framework {
	public class MobileExtender : ExtenderControl, IMobileControl {

		private Control _targetControl;
		private MobileBridge _bridge;

		public MobileExtender() : this(null) { }

		public MobileExtender(String role) {
			this.Role = role;
			this.ClientIDMode = ClientIDMode.Static;

			_bridge = new MobileBridge(this);
		}

		public Control TargetControl { get; private set; }

		//data-mini	true | false - Compact sized version
		/// <summary>
		/// Compact sized version
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("mini", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Compact sized version")]
		public Boolean Mini { get; set; }

		public String Role { get; set; }

		//data-theme	swatch letter (a-z)
		/// <summary>
		/// Defines the theme swatch letter (a-z)
		/// Reference: http://jquerymobile.com/demos/1.2.0/docs/api/data-attributes.html
		/// </summary>
		[WidgetOption("theme", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Defines the theme swatch letter (a-z)")]
		public String Theme { get; set; }

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			_targetControl = FindControl(TargetControlID);

			if(_targetControl == null) {
				throw new ArgumentNullException("TargetControl is null");
			}

			this.TargetControl = _targetControl;
		}

		protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl) {
			return null;
		}

		protected override IEnumerable<ScriptReference> GetScriptReferences() {
			return _bridge.GetScriptReferences();
		}
	}
}
