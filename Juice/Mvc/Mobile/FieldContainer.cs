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

		/// <returns>FieldContainerWidget</returns>
		public FieldContainerWidget BeginFieldContainer(String elementId = "") {
			var widget = new FieldContainerWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options();

			return widget;
		}

		public HelperResult EndFieldContainer() {
			return new HelperResult(writer => {
				(new FieldContainerWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class FieldContainerWidget : JuiceMobileWidget<FieldContainerWidget>, IDisposable {

		public FieldContainerWidget(HtmlHelper helper) : base(helper, "fieldcontain") {
			_optionsMap = new Dictionary<String, String> {

			};
		}

		public FieldContainerWidget Options() {
			base.SetOptions(

			);

			return this;
		}

	}
}
