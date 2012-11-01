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
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>TextboxWidget</returns>
		public TextboxWidget Textbox(String elementId = "", Boolean mini = false, String theme = null) {
			var widget = new TextboxWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(mini, theme);

			return widget;
		}
	}

	public class TextboxWidget : JuiceMobileWidget<TextboxWidget>, IDisposable {

		public TextboxWidget(HtmlHelper helper) : base(helper, null) {
			_optionsMap = new Dictionary<String, String> {
				{ "mini", "mini" },
				{ "theme", "theme" }
			};
		}

		public TextboxWidget Options(Boolean mini = false, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

		internal override System.Web.UI.HtmlTextWriterTag Tag {
			get {
				return System.Web.UI.HtmlTextWriterTag.Input;
			}
		}

	}
}
