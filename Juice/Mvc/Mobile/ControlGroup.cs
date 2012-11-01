using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

using Juice.Mobile;

namespace Juice.Mvc.Mobile {

	public partial class MobileHelpers {

		/// <summary>
		/// {summary}
		/// </summary>
		/// <param name="type">Add the data-type="horizontal" attribute for the selects to sit side-by-side.</param>
		/// <returns>ControlGroupWidget</returns>
		public ControlGroupWidget BeginControlGroup(String elementId = "", MobileGroupType? type = null) {
			var widget = new ControlGroupWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(type);

			return widget;
		}

		public HelperResult EndControlGroup() {
			return new HelperResult(writer => {
				(new ControlGroupWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class ControlGroupWidget : JuiceMobileWidget<ControlGroupWidget>, IDisposable {

		public ControlGroupWidget(HtmlHelper helper) : base(helper, "controlgroup") {
			_optionsMap = new Dictionary<String, String> {
				{ "type", "type" }
			};
		}

		public ControlGroupWidget Options(MobileGroupType? type = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => type)
			);

			return this;
		}

	}
}
