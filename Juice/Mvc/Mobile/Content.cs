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
		/// <param name="elementId">Sets the id attribute of the rendered element.</param>
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>ContentWidget</returns>
		public ContentWidget BeginContent(String elementId = "", String theme = null) {
			var widget = new ContentWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(theme);

			return widget;
		}

		public HelperResult EndContent() {
			return new HelperResult(writer => {
				(new ContentWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class ContentWidget : JuiceMobileWidget<ContentWidget>, IDisposable {

		public ContentWidget(HtmlHelper helper) : base(helper, "content") {
			_optionsMap = new Dictionary<String, String> {
				{ "theme", "theme" }
			};
		}

		public ContentWidget Options(String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
