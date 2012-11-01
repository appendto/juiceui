using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Themable buttons.
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the button if set to true.</param>
		/// <param name="icons">Icons to display, with or without text (see <paramref name="text"/> option).</param>
		/// <param name="label">Text to show in the button. </param>
		/// <param name="text">Whether to show the label. When set to false no text will be displayed, but the <paramref name="icons"/> option must be enabled, otherwise the text option will be ignored.</param>
		/// <returns>ButtonWidget</returns>
		public ButtonWidget Button(String elementId = "", String target = "", Boolean disabled = false, ButtonIcons icons = null, String label = null, Boolean text = true) {
			var widget = new ButtonWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled, icons, label, text);

			return widget;
		}

		/// <summary>
		/// Themable button sets.
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the button if set to true.</param>
		/// <param name="icons">Icons to display, with or without text (see <paramref name="text"/> option).</param>
		/// <param name="label">Text to show in the button. </param>
		/// <param name="text">Whether to show the label. When set to false no text will be displayed, but the <paramref name="icons"/> option must be enabled, otherwise the text option will be ignored.</param>
		/// <returns>ButtonWidget</returns>
		public ButtonWidget ButtonSet(String elementId = "", String target = "", Boolean disabled = false, ButtonIcons icons = null, String label = null, Boolean text = true) {
			var widget = new ButtonWidget(_helper);

			widget.ButtonSet = true;
			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled, icons, label, text);

			return widget;
		}

	}

	public class ButtonWidget : JuiceWidget<ButtonWidget>, IDisposable {

		public ButtonWidget(HtmlHelper helper) : base(helper, "button") { }

		internal override System.Web.UI.HtmlTextWriterTag Tag {
			get {
				return System.Web.UI.HtmlTextWriterTag.Button;
			}
		}

		public Boolean ButtonSet {
			get { return this.WidgetName == "buttonset"; }
			set { this.WidgetName = value ? "buttonset" : "button"; }
		}

		public ButtonWidget Options(Boolean disabled = false, ButtonIcons icons = null, String label = null, Boolean text = true) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => icons),
				JuiceHelpers.GetMemberInfo(() => label),
				JuiceHelpers.GetMemberInfo(() => text)
			);

			return this;
		}

	}
}
