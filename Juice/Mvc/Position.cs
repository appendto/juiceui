using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Position an element relative to another.
		/// </summary>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="my">Defines which position on the element being positioned to align with the target element: "horizontal vertical" alignment.</param>
		/// <param name="at">Defines which position on the target element to align the positioned element against: "horizontal vertical" alignment.</param>
		/// <param name="of">Which element to position against.</param>
		/// <param name="collision">When the positioned element overflows the window in some direction, move it to an alternative position.</param>
		/// <param name="within">Element to position within, affecting collision detection.</param>
		/// <returns>PositionWidget</returns>
		public PositionWidget Position(String target = "", String my = "center", String at = "center", String of = null, String collision = "flip", /* String using = null, */ String within = "window") {
			var widget = new PositionWidget(_helper);

			widget.SetCoreOptions(null, target);
			widget.Options(my, at, of, collision, within);

			return widget;
		}

	}

	public class PositionWidget : JuiceWidget<PositionWidget>, IDisposable {

		public PositionWidget(HtmlHelper helper) : base(helper, "position") { }

		public PositionWidget Options(String my = "center", String at = "center", String of = null, String collision = "flip", /* String using = null, */ String within = "window") {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => my),
				JuiceHelpers.GetMemberInfo(() => at),
				JuiceHelpers.GetMemberInfo(() => of),
				JuiceHelpers.GetMemberInfo(() => collision),
				JuiceHelpers.GetMemberInfo(() => within)
			);

			return this;
		}

	}
}
