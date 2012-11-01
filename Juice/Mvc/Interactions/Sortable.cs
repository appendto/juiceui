using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Reorder elements in a list or grid using the mouse.
		/// </summary>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Sortable if set to true.</param>
		/// <param name="appendTo">Defines where the helper that moves with the mouse is being appended to during the drag (for example, to resolve overlap/zIndex issues).</param>
		/// <param name="axis">If defined, the items can be dragged only horizontally or vertically. Possible values: "x", "y".</param>
		/// <param name="cancel">Prevents sorting if you start on elements matching the selector.</param>
		/// <param name="connectWith">A selector of other sortable elements that the items from this list should be connected to. This is a one-way relationship, if you want the items to be connected in both directions, the connectWith option must be set on both sortable elements.</param>
		/// <param name="containment">Defines a bounding box that the sortable items are contrained to while dragging.</param>
		/// <param name="cursor">Defines the cursor that is being shown while sorting.</param>
		/// <param name="cursorAt">Moves the sorting element or helper so the cursor always appears to drag from the same position. Coordinates can be given as a hash using a combination of one or two keys: { top, left, right, bottom }.</param>
		/// <param name="delay">Time in milliseconds to define when the sorting should start. Adding a delay helps preventing unwanted drags when clicking on an element.</param>
		/// <param name="distance">Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.</param>
		/// <param name="dropOnEmpty">If false, items from this sortable can't be dropped on an empty connect sortable </param>
		/// <param name="forceHelperSize">If true, forces the helper to have a size.</param>
		/// <param name="forcePlaceholderSize">If true, forces the placeholder to have a size.</param>
		/// <param name="grid">Snaps the sorting element or helper to a grid, every x and y pixels. Array values: [ x, y ].</param>
		/// <param name="handle">Restricts sort start click to the specified element.</param>
		/// <param name="helper">Allows for a helper element to be used for dragging display.</param>
		/// <param name="items">Specifies which items inside the element should be sortable.</param>
		/// <param name="opacity">Defines the opacity of the helper while sorting. From 0.01 to 1.</param>
		/// <param name="placeholder">A class name that gets applied to the otherwise white space.</param>
		/// <param name="revert">Whether the sortable items should revert to their new positions using a smooth animation.</param>
		/// <param name="scroll">If set to true, the page scrolls when coming to an edge.</param>
		/// <param name="scrollSensitivity">Defines how near the mouse must be to an edge to start scrolling.</param>
		/// <param name="scrollSpeed">The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.</param>
		/// <param name="tolerance">Specifies which mode to use for testing whether the item being moved is hovering over another item. Possible values: "intersect", "pointer"</param>
		/// <param name="zIndex">Z-index for element/helper while being sorted.</param>
		/// <returns></returns>
		public SortableWidget Sortable(String target = "", Boolean disabled = false, 
			String appendTo = "parent",
			String axis = null,
			String cancel = ":input,button",
			String connectWith = null,
			String containment = null,
			String cursor = "auto",
			CursorAt cursorAt = null,
			int delay = 0,
			int distance = 1,
			Boolean dropOnEmpty = true,
			Boolean forceHelperSize = false,
			Boolean forcePlaceholderSize = false,
			int[] grid = null,
			String handle = null,
			String helper = "original",
			String items = "> *",
			int opacity = -1,
			String placeholder = null,
			dynamic revert = null,
			Boolean scroll = true,
			int scrollSensitivity = 20,
			int scrollSpeed = 20,
			String tolerance = "intersect",
			int zIndex = 1000
			) {
			var widget = new SortableWidget(_helper);

			widget.SetCoreOptions(null, target);
			widget.Options(disabled, appendTo,
				axis,
				cancel,
				connectWith,
				containment,
				cursor,
				cursorAt,
				delay,
				distance,
				dropOnEmpty,
				forceHelperSize,
				forcePlaceholderSize,
				grid,
				handle,
				helper,
				items,
				opacity,
				placeholder,
				revert,
				scroll,
				scrollSensitivity,
				scrollSpeed,
				tolerance,
				zIndex);

			return widget;
		}

	}

	public class SortableWidget : JuiceWidget<SortableWidget>, IDisposable {

		public SortableWidget(HtmlHelper helper) : base(helper, "sortable") { }

		public SortableWidget Options(Boolean disabled = false,
			String appendTo = "parent",
			String axis = null,
			String cancel = ":input,button",
			String connectWith = null,
			String containment = null,
			String cursor = "auto",
			CursorAt cursorAt = null,
			int delay = 0,
			int distance = 1,
			Boolean dropOnEmpty = true,
			Boolean forceHelperSize = false,
			Boolean forcePlaceholderSize = false,
			int[] grid = null,
			String handle = null,
			String helper = "original",
			String items = "> *",
			int opacity = -1,
			String placeholder = null,
			dynamic revert = null,
			Boolean scroll = true,
			int scrollSensitivity = 20,
			int scrollSpeed = 20,
			String tolerance = "intersect",
			int zIndex = 1000			
			) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => appendTo),
				JuiceHelpers.GetMemberInfo(() => axis),
				JuiceHelpers.GetMemberInfo(() => cancel),
				JuiceHelpers.GetMemberInfo(() => connectWith),
				JuiceHelpers.GetMemberInfo(() => containment),
				JuiceHelpers.GetMemberInfo(() => cursor),
				JuiceHelpers.GetMemberInfo(() => cursorAt),
				JuiceHelpers.GetMemberInfo(() => delay),
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => distance),
				JuiceHelpers.GetMemberInfo(() => dropOnEmpty),
				JuiceHelpers.GetMemberInfo(() => forceHelperSize),
				JuiceHelpers.GetMemberInfo(() => forcePlaceholderSize),
				JuiceHelpers.GetMemberInfo(() => grid),
				JuiceHelpers.GetMemberInfo(() => handle),
				JuiceHelpers.GetMemberInfo(() => helper),
				JuiceHelpers.GetMemberInfo(() => items),
				JuiceHelpers.GetMemberInfo(() => opacity),
				JuiceHelpers.GetMemberInfo(() => placeholder),
				JuiceHelpers.GetMemberInfo(() => revert),
				JuiceHelpers.GetMemberInfo(() => scroll),
				JuiceHelpers.GetMemberInfo(() => scrollSensitivity),
				JuiceHelpers.GetMemberInfo(() => scrollSpeed),
				JuiceHelpers.GetMemberInfo(() => tolerance),
				JuiceHelpers.GetMemberInfo(() => zIndex)
			);

			return this;
		}

	}
}
