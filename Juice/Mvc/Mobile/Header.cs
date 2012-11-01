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
		/// <param name="position">Where to position the footer. Accepts fixed.</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>HeaderWidget</returns>
		public HeaderWidget BeginHeader(String elementId = "", MobilePosition? position = null, String theme = null) {
			var widget = new HeaderWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(position, theme);

			return widget;
		}

		public HelperResult EndHeader() {
			return new HelperResult(writer => {
				(new HeaderWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class HeaderWidget : JuiceMobileWidget<HeaderWidget>, IDisposable {

		public HeaderWidget(HtmlHelper helper) : base(helper, "header") {
			_optionsMap = new Dictionary<String, String> {
				{ "position", "position" },
				{ "theme", "theme" }
			};
		}

		public HeaderWidget Options(MobilePosition? position = null, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => position),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
