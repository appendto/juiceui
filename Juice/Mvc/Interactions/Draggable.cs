using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Allow elements to be moved using the mouse.
		/// </summary>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Draggable if set to true.</param>
		/// <param name="addClasses">If set to false, will prevent the ui-draggable class from being added. This may be desired as a performance optimization when calling .draggable() on hundreds of elements.</param>
		/// <param name="appendTo">Which element the draggable helper should be appended to while dragging.</param>
		/// <param name="axis">Constrains dragging to either the horizontal (x) or vertical (y) axis. Possible values: "x", "y".</param>
		/// <param name="cancel">Prevents dragging from starting on specified elements.</param>
		/// <param name="connectToSortable">Allows the draggable to be dropped onto the specified sortables. If this option is used, a draggable can be dropped onto a sortable list and then becomes part of it. </param>
		/// <param name="containment">Constrains dragging to within the bounds of the specified element or region.</param>
		/// <param name="cursor">The CSS cursor during the drag operation.</param>
		/// <param name="cursorAt">Sets the offset of the dragging helper relative to the mouse cursor. Coordinates can be given as a hash using a combination of one or two keys: { top, left, right, bottom }.</param>
		/// <param name="delay">Time in milliseconds after mousedown until dragging should start. This option can be used to prevent unwanted drags when clicking on an element.</param>
		/// <param name="distance">Distance in pixels after mousedown the mouse must move before dragging should start. This option can be used to prevent unwanted drags when clicking on an element.</param>
		/// <param name="grid">Snaps the dragging helper to a grid, every x and y pixels. The array must be of the form [ x, y ].</param>
		/// <param name="handle">If specified, restricts dragging from starting unless the mousedown occurs on the specified element(s).</param>
		/// <param name="helper">Allows for a helper element to be used for dragging display.</param>
		/// <param name="iframeFix">Prevent iframes from capturing the mousemove events during a drag. Useful in combination with the cursorAt option, or in any case where the mouse cursor may not be over the helper.</param>
		/// <param name="opacity">Opacity for the helper while being dragged.</param>
		/// <param name="refreshPositions">If set to true, all droppable positions are calculated on every mousemove. Caution: This solves issues on highly dynamic pages, but dramatically decreases performance.</param>
		/// <param name="revert">Whether the element should revert to its start position when dragging stops.</param>
		/// <param name="revertDuration">The duration of the revert animation, in milliseconds. Ignored if the revert option is false.</param>
		/// <param name="scope">Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted by the droppable.</param>
		/// <param name="scroll">If set to true, container auto-scrolls while dragging.</param>
		/// <param name="scrollSensitivity">Distance in pixels from the edge of the viewport after which the viewport should scroll. Distance is relative to pointer, not the draggable. Ignored if the scroll option is false.</param>
		/// <param name="scrollSpeed">The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance. Ignored if the scroll option is false.</param>
		/// <param name="snap">Whether the element should snap to other elements.</param>
		/// <param name="snapMode">Determines which edges of snap elements the draggable will snap to. Ignored if the snap option is false. Possible values: "inner", "outer", "both".</param>
		/// <param name="snapTolerance">The distance in pixels from the snap element edges at which snapping should occur. Ignored if the snap option is false.</param>
		/// <param name="stack">Controls the z-index of the set of elements that match the selector, always brings the currently dragged item to the front. Very useful in things like window managers.</param>
		/// <param name="zIndex">Z-index for the helper while being dragged.</param>
		/// <returns>DraggableWidget</returns>
		public DraggableWidget Draggable(String target = "", Boolean disabled = false, 
			Boolean addClasses = true,
			String appendTo = "parent",
			String axis = null,
			String cancel = "input,textarea,button,select,option",
			String connectToSortable = null,
			dynamic containment = null,
			String cursor = "auto",
			CursorAt cursorAt = null,
			int delay = 0,
			int distance = 1,
			int[] grid = null,
			String handle = null,
			String helper = "original",
			dynamic iframeFix = null,
			int opacity = -1,
			Boolean refreshPositions = false,
			dynamic revert = null,
			int revertDuration = 500,
			String scope = "default",
			Boolean scroll = true,
			int scrollSensitivity = 20,
			int scrollSpeed = 20,
			dynamic snap = null,
			String snapMode = "both",
			int snapTolerance = 20,
			String stack = null,
			int zIndex = -1
			) {
			var widget = new DraggableWidget(_helper);

			widget.SetCoreOptions(null, target);
			widget.Options(disabled, 
				addClasses,
				appendTo,
				axis,
				cancel,
				connectToSortable,
				containment,
				cursor,
				cursorAt,
				delay,
				distance,
				grid,
				handle,
				helper,
				iframeFix,
				opacity,
				refreshPositions,
				revert,
				revertDuration,
				scope,
				scroll,
				scrollSensitivity,
				scrollSpeed,
				snap,
				snapMode,
				snapTolerance,
				stack,
				zIndex
				);

			return widget;
		}

	}

	public class DraggableWidget : JuiceWidget<DraggableWidget>, IDisposable {

		public DraggableWidget(HtmlHelper helper) : base(helper, "draggable") { }

		public DraggableWidget Options(Boolean disabled = false,
			Boolean addClasses = true,
			String appendTo = "parent",
			String axis = null,
			String cancel = "input,textarea,button,select,option",
			String connectToSortable = null,
			dynamic containment = null,
			String cursor = "auto",
			CursorAt cursorAt = null,
			int delay = 0,
			int distance = 1,
			int[] grid = null,
			String handle = null,
			String helper = "original",
			dynamic iframeFix = null,
			int opacity = -1,
			Boolean refreshPositions = false,
			dynamic revert = null,
			int revertDuration = 500,
			String scope = "default",
			Boolean scroll = true,
			int scrollSensitivity = 20,
			int scrollSpeed = 20,
			dynamic snap = null,
			String snapMode = "both",
			int snapTolerance = 20,
			String stack = null,
			int zIndex = -1			
			) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => addClasses),
				JuiceHelpers.GetMemberInfo(() => appendTo),
				JuiceHelpers.GetMemberInfo(() => axis),
				JuiceHelpers.GetMemberInfo(() => cancel),
				JuiceHelpers.GetMemberInfo(() => connectToSortable),
				JuiceHelpers.GetMemberInfo(() => containment),
				JuiceHelpers.GetMemberInfo(() => cursor),
				JuiceHelpers.GetMemberInfo(() => cursorAt),
				JuiceHelpers.GetMemberInfo(() => delay),
				JuiceHelpers.GetMemberInfo(() => distance),
				JuiceHelpers.GetMemberInfo(() => grid),
				JuiceHelpers.GetMemberInfo(() => handle),
				JuiceHelpers.GetMemberInfo(() => helper),
				JuiceHelpers.GetMemberInfo(() => iframeFix),
				JuiceHelpers.GetMemberInfo(() => opacity),
				JuiceHelpers.GetMemberInfo(() => refreshPositions),
				JuiceHelpers.GetMemberInfo(() => revert),
				JuiceHelpers.GetMemberInfo(() => revertDuration),
				JuiceHelpers.GetMemberInfo(() => scope),
				JuiceHelpers.GetMemberInfo(() => scroll),
				JuiceHelpers.GetMemberInfo(() => scrollSensitivity),
				JuiceHelpers.GetMemberInfo(() => scrollSpeed),
				JuiceHelpers.GetMemberInfo(() => snap),
				JuiceHelpers.GetMemberInfo(() => snapMode),
				JuiceHelpers.GetMemberInfo(() => snapTolerance),
				JuiceHelpers.GetMemberInfo(() => stack),
				JuiceHelpers.GetMemberInfo(() => zIndex)
			);

			return this;
		}

	}
}
