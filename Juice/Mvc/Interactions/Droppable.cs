using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Display status of a determinate process.
		/// </summary>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Droppable if set to true.</param>
		/// <param name="accept">Controls which Droppable elements are accepted by the droppable.</param>
		/// <param name="activeClass">If specified, the class will be added to the droppable while an acceptable Droppable is being dragged.</param>
		/// <param name="addClasses">If set to false, will prevent the ui-droppable class from being added. </param>
		/// <param name="greedy">By default, when an element is dropped on nested droppables, each droppable will receive the element. </param>
		/// <param name="hoverClass">If specified, the class will be added to the droppable while an acceptable Droppable is being hovered over the droppable.</param>
		/// <param name="scope">Used to group sets of Droppable and droppable items, in addition to the accept option.</param>
		/// <param name="tolerance">Specifies which mode to use for testing whether a Droppable is hovering over a droppable. </param>
		/// <returns>DroppableWidget</returns>
		public DroppableWidget Droppable(String target = "", Boolean disabled = false, String accept = "*", String activeClass = null, Boolean addClasses = true, Boolean greedy = false, String hoverClass = null, String scope = "default", String tolerance = "intersect") {
			var widget = new DroppableWidget(_helper);

			widget.SetCoreOptions(null, target);
			widget.Options(disabled, accept, activeClass, addClasses, greedy, hoverClass, scope, tolerance);

			return widget;
		}

	}

	public class DroppableWidget : JuiceWidget<DroppableWidget>, IDisposable {

		public DroppableWidget(HtmlHelper helper) : base(helper, "droppable") { }

		public DroppableWidget Options(Boolean disabled = false, String accept = "*", String activeClass = null, Boolean addClasses = true, Boolean greedy = false, String hoverClass = null, String scope = "default", String tolerance = "intersect") {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => accept),
				JuiceHelpers.GetMemberInfo(() => activeClass),
				JuiceHelpers.GetMemberInfo(() => addClasses),
				JuiceHelpers.GetMemberInfo(() => greedy),
				JuiceHelpers.GetMemberInfo(() => hoverClass),
				JuiceHelpers.GetMemberInfo(() => scope),
				JuiceHelpers.GetMemberInfo(() => tolerance)
			);

			return this;
		}

	}
}
