using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Display status of a determinate process.
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the progressbar if set to true.</param>
		/// <param name="value">The value of the progressbar.</param>
		/// <returns>ProgressbarWidget</returns>
		public ProgressbarWidget Progressbar(String elementId = "", String target = "", Boolean disabled = false, int value = 0) {
			var widget = new ProgressbarWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled, value);

			return widget;
		}

	}

	public class ProgressbarWidget : JuiceWidget<ProgressbarWidget>, IDisposable {

		public ProgressbarWidget(HtmlHelper helper) : base(helper, "progressbar") { }

		public ProgressbarWidget Options(Boolean disabled = false, int value = 0) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => value)
			);

			return this;
		}

	}
}
