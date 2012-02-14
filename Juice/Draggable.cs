using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;


using Juice.Framework;

namespace Juice {

	/// <summary>
	/// Extend a WebControl or HtmlControl with jQuery UI Draggable http://jqueryui.com/demos/draggable/
	/// </summary>
	[TargetControlType(typeof(WebControl))]
	[TargetControlType(typeof(HtmlControl))]
	[WidgetEvent("create")]
	[WidgetEvent("start")]
	[WidgetEvent("drag")]
	public class Draggable : JuiceExtender {

		public Draggable() : base("draggable") { }

		#region Widget Options

		/// <summary>
		/// If set to false, will prevent the ui-draggable class from being added. This may be desired as a performance optimization when calling .draggable() init on many hundreds of elements.
		/// Reference: http://jqueryui.com/demos/draggable/#addClasses
		/// </summary>
		[WidgetOption("addClasses", true)]
		public bool AddClasses { get; set; }

		/// <summary>
		/// The element passed to or selected by the appendTo option will be used as the draggable helper's container during dragging. By default, the helper is appended to the same container as the draggable.
		/// Reference: http://jqueryui.com/demos/draggable/#appendTo
		/// </summary>
		[WidgetOption("appendTo", "parent")]
		public string AppendTo { get; set; }

		/// <summary>
		/// Constrains dragging to either the horizontal (x) or vertical (y) axis. Possible values: 'x', 'y'.
		/// Reference: http://jqueryui.com/demos/draggable/#axis
		/// </summary>
		[WidgetOption("axis", null)]
		public string Axis { get; set; }

		/// <summary>
		/// Prevents dragging from starting on specified elements.
		/// Reference: http://jqueryui.com/demos/draggable/#cancel
		/// </summary>
		[WidgetOption("cancel", ":input,option")]
		public string Cancel { get; set; }

		/// <summary>
		/// Allows the draggable to be dropped onto the specified sortables. If this option is used (helper must be set to 'clone' in order to work flawlessly), a draggable can be dropped onto a sortable list and then becomes part of it.
		/// Reference: http://jqueryui.com/demos/draggable/#connectToSortable
		/// </summary>
		[WidgetOption("connectToSortable", null)]
		public string ConnectToSortable { get; set; }

		/// <summary>
		/// Constrains dragging to within the bounds of the specified element or region. Possible string values: 'parent', 'document', 'window', [x1, y1, x2, y2].
		/// Reference: http://jqueryui.com/demos/draggable/#containment
		/// </summary>
		[WidgetOption("containment", null)]
		public string Containment { get; set; }

		/// <summary>
		/// The css cursor during the drag operation.
		/// Reference: http://jqueryui.com/demos/draggable/#cursor
		/// </summary>
		[WidgetOption("cursor", "auto")]
		public string Cursor { get; set; }

		/// <summary>
		/// Sets the offset of the dragging helper relative to the mouse cursor. Coordinates can be given as a hash using a combination of one or two keys: { top, left, right, bottom }.
		/// Reference: http://jqueryui.com/demos/draggable/#cursorAt
		/// </summary>
		[WidgetOption("cursorAt", null)]
		public string CursorAt { get; set; }

		/// <summary>
		/// Time in milliseconds after mousedown until dragging should start. This option can be used to prevent unwanted drags when clicking on an element.
		/// Reference: http://jqueryui.com/demos/draggable/#delay
		/// </summary>
		[WidgetOption("delay", 0)]
		public int Delay { get; set; }

		/// <summary>
		/// Distance in pixels after mousedown the mouse must move before dragging should start. This option can be used to prevent unwanted drags when clicking on an element.
		/// Reference: http://jqueryui.com/demos/draggable/#distance
		/// </summary>
		[WidgetOption("distance", 1)]
		public int Distance { get; set; }

		/// <summary>
		/// Snaps the dragging helper to a grid, every x and y pixels. Array values: [x, y]
		/// Reference: http://jqueryui.com/demos/draggable/#grid
		/// </summary>
		[WidgetOption("grid", null)]
		[TypeConverter(typeof(Int32ArrayConverter))]
		public int[] Grid { get; set; }

		/// <summary>
		/// If specified, restricts drag start click to the specified element(s).
		/// Reference: http://jqueryui.com/demos/draggable/#handle
		/// </summary>
		[WidgetOption("handle", null)]
		public string Handle { get; set; }

		/// <summary>
		/// Allows for a helper element to be used for dragging display. Possible values: 'original', 'clone', Function. If a function is specified, it must return a DOMElement.
		/// Reference: http://jqueryui.com/demos/draggable/#helper
		/// </summary>
		[WidgetOption("helper", "original")]
		public string Helper { get; set; }

		/// <summary>
		/// Prevent iframes from capturing the mousemove events during a drag. Useful in combination with cursorAt, or in any case, if the mouse cursor is not over the helper. If set to true, transparent overlays will be placed over all iframes on the page. If a selector is supplied, the matched iframes will have an overlay placed over them.
		/// Reference: http://jqueryui.com/demos/draggable/#iframeFix
		/// </summary>
		[WidgetOption("iframeFix", null)]
		public string IframeFix { get; set; }

		/// <summary>
		/// Opacity for the helper while being dragged (e.g. 0.5 results in 50% opacity while dragging).
		/// Reference: http://jqueryui.com/demos/draggable/#opacity
		/// </summary>
		[WidgetOption("opacity", null)]
		public float? Opacity { get; set; }

		/// <summary>
		/// If set to true, all droppable positions are calculated on every mousemove. Caution: This solves issues on highly dynamic pages, but dramatically decreases performance.
		/// Reference: http://jqueryui.com/demos/draggable/#refreshPositions
		/// </summary>
		[WidgetOption("refreshPositions", false)]
		public bool RefreshPositions { get; set; }

		/// <summary>
		/// If set to true, the element will return to its start position when dragging stops. Possible string values: 'valid', 'invalid'. If set to invalid, revert will only occur if the draggable has not been dropped on a droppable. For valid, it's the other way around.
		/// Reference: http://jqueryui.com/demos/draggable/#revert
		/// </summary>
		[WidgetOption("revert", null)]
		public string Revert { get; set; }

		/// <summary>
		/// The duration of the revert animation, in milliseconds. Ignored if revert is false.
		/// Reference: http://jqueryui.com/demos/draggable/#revertDuration
		/// </summary>
		[WidgetOption("revertDuration", 500)]
		public int RevertDuration { get; set; }

		/// <summary>
		/// Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted by the droppable.
		/// Reference: http://jqueryui.com/demos/draggable/#scope
		/// </summary>
		[WidgetOption("scope", "default")]
		public string Scope { get; set; }

		/// <summary>
		/// If set to true, container auto-scrolls while dragging.
		/// Reference: http://jqueryui.com/demos/draggable/#scroll
		/// </summary>
		[WidgetOption("scroll", true)]
		public bool Scroll { get; set; }

		/// <summary>
		/// Distance in pixels from the edge of the viewport after which the viewport should scroll. Distance is relative to pointer, not the draggable.
		/// Reference: http://jqueryui.com/demos/draggable/#scrollSensitivity
		/// </summary>
		[WidgetOption("scrollSensitivity", 20)]
		public int ScrollSensitivity { get; set; }

		/// <summary>
		/// The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.
		/// Reference: http://jqueryui.com/demos/draggable/#scrollSpeed
		/// </summary>
		[WidgetOption("scrollSpeed", 20)]
		public int ScrollSpeed { get; set; }

		/// <summary>
		/// If set to a selector or to true (equivalent to '.ui-draggable'), the draggable will snap to the edges of the selected elements when near an edge of the element.
		/// Reference: http://jqueryui.com/demos/draggable/#snap
		/// </summary>
		[WidgetOption("snap", null)]
		public string Snap { get; set; }

		/// <summary>
		/// Determines which edges of snap elements the draggable will snap to. Ignored if snap is false. Possible values: 'inner', 'outer', 'both'
		/// Reference: http://jqueryui.com/demos/draggable/#snapMode
		/// </summary>
		[WidgetOption("snapMode", "both")]
		public string SnapMode { get; set; }

		/// <summary>
		/// The distance in pixels from the snap element edges at which snapping should occur. Ignored if snap is false.
		/// Reference: http://jqueryui.com/demos/draggable/#snapTolerance
		/// </summary>
		[WidgetOption("snapTolerance", 20)]
		public int SnapTolerance { get; set; }

		/// <summary>
		/// Controls the z-Index of the set of elements that match the selector, always brings to front the dragged item. Very useful in things like window managers.
		/// Reference: http://jqueryui.com/demos/draggable/#stack
		/// </summary>
		[WidgetOption("stack", null)]
		public string Stack { get; set; }

		/// <summary>
		/// z-index for the helper while being dragged.
		/// Reference: http://jqueryui.com/demos/draggable/#zIndex
		/// </summary>
		[WidgetOption("zIndex", null)]
		public int? ZIndex { get; set; }

		#endregion

		#region Widget Events

		/// <summary>
		/// This event is triggered when dragging stops.
		/// Reference: http://jqueryui.com/demos/draggable/#stop
		/// </summary>
		[WidgetEvent("stop")]
		public event EventHandler Stop;

		#endregion

	}
}
