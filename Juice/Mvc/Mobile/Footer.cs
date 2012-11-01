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
		/// <returns>FooterWidget</returns>
		public FooterWidget BeginFooter(String elementId = "", MobilePosition? position = null, String theme = null) {
			var widget = new FooterWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(position, theme);

			return widget;
		}

		public HelperResult EndFooter() {
			return new HelperResult(writer => {
				(new FooterWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class FooterWidget : JuiceMobileWidget<FooterWidget>, IDisposable {

		public FooterWidget(HtmlHelper helper) : base(helper, "footer") {
			_optionsMap = new Dictionary<String, String> {
				{ "position", "position" },
				{ "theme", "theme" }
			};
		}

		public FooterWidget Options(MobilePosition? position = null, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => position),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
