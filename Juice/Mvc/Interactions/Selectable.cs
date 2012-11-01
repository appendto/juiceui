using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Use the mouse to select elements, individually or in a group.
		/// </summary>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Selectable if set to true.</param>
		/// <param name="autoRefresh">This determines whether to refresh (recalculate) the position and size of each selectee at the beginning of each select operation. </param>
		/// <param name="cancel">Prevents selecting if you start on elements matching the selector.</param>
		/// <param name="delay">Time in milliseconds to define when the selecting should start. This helps prevent unwanted selections when clicking on an element.</param>
		/// <param name="distance">Tolerance, in pixels, for when selecting should start.</param>
		/// <param name="filter">The matching child elements will be made selectees (able to be selected).</param>
		/// <param name="tolerance">Specifies which mode to use for testing whether the lasso should select an item. </param>
		/// <returns>SelectableWidget</returns>
		public SelectableWidget Selectable(String target = "", Boolean disabled = false, Boolean autoRefresh = true, String cancel = "input,textarea,button,select,option", int delay = 0, int distance = 0, String filter = "*", String tolerance = "touch") {
			var widget = new SelectableWidget(_helper);

			widget.SetCoreOptions(null, target);
			widget.Options(disabled, autoRefresh, cancel, delay, distance, filter, tolerance);

			return widget;
		}

	}

	public class SelectableWidget : JuiceWidget<SelectableWidget>, IDisposable {

		public SelectableWidget(HtmlHelper helper) : base(helper, "selectable") { }

		public SelectableWidget Options(Boolean disabled = false, Boolean autoRefresh = true, String cancel = "input,textarea,button,select,option", int delay = 0, int distance = 0, String filter = "*", String tolerance = "touch") {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => autoRefresh),
				JuiceHelpers.GetMemberInfo(() => cancel),
				JuiceHelpers.GetMemberInfo(() => delay),
				JuiceHelpers.GetMemberInfo(() => distance),
				JuiceHelpers.GetMemberInfo(() => filter),
				JuiceHelpers.GetMemberInfo(() => tolerance)
			);

			return this;
		}

	}
}
