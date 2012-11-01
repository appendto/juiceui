using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Customizable, themeable tooltips, replacing native tooltips.
		/// </summary>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Tooltip if set to true.</param>
		/// <param name="content">The content of the tooltip. When changing this option, you likely need to also change the items option.</param>
		/// <param name="hide">If and how to animate the hiding of the tooltip.</param>
		/// <param name="items">A selector indicating which items should show tooltips. Customize if you're using something other then the title attribute for the tooltip content, or if you need a different selector for event delegation.</param>
		/// <param name="show">If and how to animate the showing of the tooltip.</param>
		/// <param name="tooltipClass">A class to add to the widget, can be used to display various tooltip types, like warnings or errors.</param>
		/// <param name="track">Whether the tooltip should track (follow) the mouse.</param>
		/// <returns>TooltipWidget</returns>
		public TooltipWidget Tooltip(String target = "", Boolean disabled = false, String content = null, dynamic hide = null, String items = "[title]", dynamic show = null, String tooltipClass = null, Boolean track = false) {
			var widget = new TooltipWidget(_helper);

			widget.SetCoreOptions(null, target);
			widget.Options(disabled, content, hide, items, show, tooltipClass, track);

			return widget;
		}

	}

	public class TooltipWidget : JuiceWidget<TooltipWidget>, IDisposable {

		public TooltipWidget(HtmlHelper helper) : base(helper, "tooltip") { }

		public TooltipWidget Options(Boolean disabled = false, String content = null, dynamic hide = null, String items = "[title]", dynamic show = null, String tooltipClass = null, Boolean track = false) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => content),
				JuiceHelpers.GetMemberInfo(() => hide),
				JuiceHelpers.GetMemberInfo(() => items),
				JuiceHelpers.GetMemberInfo(() => show),
				JuiceHelpers.GetMemberInfo(() => tooltipClass),
				JuiceHelpers.GetMemberInfo(() => track)
			);

			return this;
		}

	}
}
