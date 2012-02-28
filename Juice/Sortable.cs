using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice {

	/// <summary>
	/// Extend a Control with the jQuery UI Sortable behavior http://jqueryui.com/demos/sortable/
	/// </summary>
	[TargetControlType(typeof(WebControl))]
	[TargetControlType(typeof(System.Web.UI.HtmlControls.HtmlControl))]
	[WidgetEvent("create")]
	[WidgetEvent("start")]
	[WidgetEvent("sort")]
	[WidgetEvent("change")]
	[WidgetEvent("beforeStop")]
	[WidgetEvent("update")]
	[WidgetEvent("over")]
	[WidgetEvent("out")]
	[WidgetEvent("activate")]
	[WidgetEvent("deactivate")]
	public class Sortable : JuiceExtender {

		public Sortable() : base("sortable") { }

		#region Widget Options

		/// <summary>
		/// Defines where the helper that moves with the mouse is being appended to during the drag (for example, to resolve overlap/zIndex issues).
		/// Reference: http://jqueryui.com/demos/sortable/#appendTo
		/// </summary>
		[WidgetOption("appendTo", "parent")]
		[Category("Behavior")]
		[DefaultValue("parent")]
		[Description("Defines where the helper that moves with the mouse is being appended to during the drag (for example, to resolve overlap/zIndex issues).")]
		public string AppendTo { get; set; }

		/// <summary>
		/// If defined, the items can be dragged only horizontally or vertically. Possible values:'x', 'y'.
		/// Reference: http://jqueryui.com/demos/sortable/#axis
		/// </summary>
		[WidgetOption("axis", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If defined, the items can be dragged only horizontally or vertically. Possible values:'x', 'y'.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Axis { get; set; }

		/// <summary>
		/// Prevents sorting if you start on elements matching the selector.
		/// Reference: http://jqueryui.com/demos/sortable/#cancel
		/// </summary>
		[WidgetOption("cancel", ":input,button")]
		[Category("Behavior")]
		[DefaultValue(":input,button")]
		[Description("Prevents sorting if you start on elements matching the selector.")]
		public string Cancel { get; set; }

		/// <summary>
		/// Takes a jQuery selector with items that also have sortables applied. If used, the sortable is now connected to the other one-way, so you can drag from this sortable to the other.
		/// Reference: http://jqueryui.com/demos/sortable/#connectWith
		/// </summary>
		[WidgetOption("connectWith", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Takes a jQuery selector with items that also have sortables applied. If used, the sortable is now connected to the other one-way, so you can drag from this sortable to the other.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic ConnectWith { get; set; }

		/// <summary>
		/// Constrains dragging to within the bounds of the specified element - can be a DOM element, 'parent', 'document', 'window', or a jQuery selector.
		/// Note: the element specified for containment must have a calculated width and height (though it need not be explicit), so for example, if you have float:left sortable children and specify containment:'parent' be sure to have float:left on the sortable/parent container as well or it will have height: 0, causing undefined behavior.
		/// Reference: http://jqueryui.com/demos/sortable/#containment
		/// </summary>
		[WidgetOption("containment", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Constrains dragging to within the bounds of the specified element - can be a DOM element, 'parent', 'document', 'window', or a jQuery selector. \nNote: the element specified for containment must have a calculated width and height (though it need not be explicit), so for example, if you have float:left sortable children and specify containment:'parent' be sure to have float:left on the sortable/parent container as well or it will have height: 0, causing undefined behavior.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Containment { get; set; }

		/// <summary>
		/// Defines the cursor that is being shown while sorting.
		/// Reference: http://jqueryui.com/demos/sortable/#cursor
		/// </summary>
		[WidgetOption("cursor", "auto")]
		[Category("Appearance")]
		[DefaultValue("auto")]
		[Description("Defines the cursor that is being shown while sorting.")]
		public string Cursor { get; set; }

		/// <summary>
		/// Moves the sorting element or helper so the cursor always appears to drag from the same position. Coordinates can be given as a hash using a combination of one or two keys: { top, left, right, bottom }.
		/// Reference: http://jqueryui.com/demos/sortable/#cursorAt
		/// </summary>
		[WidgetOption("cursorAt", "{}", Eval=true)]
		[Category("Behavior")]
		[DefaultValue("{}")]
		[Description("Moves the sorting element or helper so the cursor always appears to drag from the same position. Coordinates can be given as a hash using a combination of one or two keys: { top, left, right, bottom }.")]
		public string CursorAt { get; set; }

		/// <summary>
		/// Time in milliseconds to define when the sorting should start. It helps preventing unwanted drags when clicking on an element.
		/// Reference: http://jqueryui.com/demos/sortable/#delay
		/// </summary>
		[WidgetOption("delay", 0)]
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Time in milliseconds to define when the sorting should start. It helps preventing unwanted drags when clicking on an element.")]
		public int Delay { get; set; }

		/// <summary>
		/// Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
		/// Reference: http://jqueryui.com/demos/sortable/#distance
		/// </summary>
		[WidgetOption("distance", 1)]
		[Category("Behavior")]
		[DefaultValue(1)]
		[Description("Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.")]
		public int Distance { get; set; }

		/// <summary>
		/// If false items from this sortable can't be dropped to an empty linked sortable.
		/// Reference: http://jqueryui.com/demos/sortable/#dropOnEmpty
		/// </summary>
		[WidgetOption("dropOnEmpty", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If false items from this sortable can't be dropped to an empty linked sortable.")]
		public bool DropOnEmpty { get; set; }

		/// <summary>
		/// If true, forces the helper to have a size.
		/// Reference: http://jqueryui.com/demos/sortable/#forceHelperSize
		/// </summary>
		[WidgetOption("forceHelperSize", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If true, forces the helper to have a size.")]
		public bool ForceHelperSize { get; set; }

		/// <summary>
		/// If true, forces the placeholder to have a size.
		/// Reference: http://jqueryui.com/demos/sortable/#forcePlaceholderSize
		/// </summary>
		[WidgetOption("forcePlaceholderSize", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If true, forces the placeholder to have a size.")]
		public bool ForcePlaceholderSize { get; set; }

		/// <summary>
		/// Snaps the sorting element or helper to a grid, every x and y pixels. Array values: [x, y]
		/// Reference: http://jqueryui.com/demos/sortable/#grid
		/// </summary>
		[WidgetOption("grid", null)]
		[TypeConverter(typeof(Int32ArrayConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Snaps the sorting element or helper to a grid, every x and y pixels. Array values: [x, y]")]
		public int[] Grid { get; set; }

		/// <summary>
		/// Restricts sort start click to the specified element.
		/// Reference: http://jqueryui.com/demos/sortable/#handle
		/// </summary>
		[WidgetOption("handle", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Restricts sort start click to the specified element.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Handle { get; set; }

		/// <summary>
		/// Allows for a helper element to be used for dragging display. Possible values: 'original', 'clone'
		/// Reference: http://jqueryui.com/demos/sortable/#helper
		/// </summary>
		[WidgetOption("helper", "original")]
		[Category("Behavior")]
		[DefaultValue("original")]
		[Description("Allows for a helper element to be used for dragging display. Possible values: 'original', 'clone'")]
		public string Helper { get; set; }

		/// <summary>
		/// Specifies which items inside the element should be sortable.
		/// Reference: http://jqueryui.com/demos/sortable/#items
		/// </summary>
		[WidgetOption("items", "> *")]
		[Category("Behavior")]
		[DefaultValue("> *")]
		[Description("Specifies which items inside the element should be sortable.")]
		public string Items { get; set; }

		/// <summary>
		/// Defines the opacity of the helper while sorting. From 0.01 to 1
		/// Reference: http://jqueryui.com/demos/sortable/#opacity
		/// </summary>
		[WidgetOption("opacity", 1)]
		[Category("Appearance")]
		[DefaultValue(1)]
		[Description("Defines the opacity of the helper while sorting. From 0.01 to 1")]
		public float Opacity { get; set; }

		/// <summary>
		/// Class that gets applied to the otherwise white space.
		/// Reference: http://jqueryui.com/demos/sortable/#placeholder
		/// </summary>
		[WidgetOption("placeholder", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Class that gets applied to the otherwise white space.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Placeholder { get; set; }

		/// <summary>
		/// If set to true, the item will be reverted to its new DOM position with a smooth animation. Optionally, it can also be set to a number that controls the duration of the animation in ms.
		/// Reference: http://jqueryui.com/demos/sortable/#revert
		/// </summary>
		[WidgetOption("revert", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, the item will be reverted to its new DOM position with a smooth animation. Optionally, it can also be set to a number that controls the duration of the animation in ms.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Revert { get; set; }

		/// <summary>
		/// If set to true, the page scrolls when coming to an edge.
		/// Reference: http://jqueryui.com/demos/sortable/#scroll
		/// </summary>
		[WidgetOption("scroll", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to true, the page scrolls when coming to an edge.")]
		public bool Scroll { get; set; }

		/// <summary>
		/// Defines how near the mouse must be to an edge to start scrolling.
		/// Reference: http://jqueryui.com/demos/sortable/#scrollSensitivity
		/// </summary>
		[WidgetOption("scrollSensitivity", 20)]
		[Category("Behavior")]
		[DefaultValue(20)]
		[Description("Defines how near the mouse must be to an edge to start scrolling.")]
		public int ScrollSensitivity { get; set; }

		/// <summary>
		/// The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.
		/// Reference: http://jqueryui.com/demos/sortable/#scrollSpeed
		/// </summary>
		[WidgetOption("scrollSpeed", 20)]
		[Category("Behavior")]
		[DefaultValue(20)]
		[Description("The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.")]
		public int ScrollSpeed { get; set; }

		/// <summary>
		/// This is the way the reordering behaves during drag. Possible values: 'intersect', 'pointer'. In some setups, 'pointer' is more natural.
		/// Reference: http://jqueryui.com/demos/sortable/#tolerance
		/// </summary>
		[WidgetOption("tolerance", "intersect")]
		[Category("Behavior")]
		[DefaultValue("intersect")]
		[Description("This is the way the reordering behaves during drag. Possible values: 'intersect', 'pointer'. In some setups, 'pointer' is more natural.")]
		public string Tolerance { get; set; }

		/// <summary>
		/// Z-index for element/helper while being sorted.
		/// Reference: http://jqueryui.com/demos/sortable/#zIndex
		/// </summary>
		[WidgetOption("zIndex", 1000)]
		[Category("Layout")]
		[DefaultValue(1000)]
		[Description("Z-index for element/helper while being sorted.")]
		public int ZIndex { get; set; }

		#endregion

		#region Widget Events

		/// <summary>
		/// This event is triggered when sorting has stopped.
		/// Reference: http://jqueryui.com/demos/sortable/#stop
		/// </summary>
		[WidgetEvent("stop")]
		[Category("Action")]
		[Description("This event is triggered when sorting has stopped.")]
		public event EventHandler Stop;

		/// <summary>
		/// This event is triggered when a connected sortable list has received an item from another list.
		/// Reference: http://jqueryui.com/demos/sortable/#receive
		/// </summary>
		[WidgetEvent("receive")]
		[Category("Action")]
		[Description("This event is triggered when a connected sortable list has received an item from another list.")]
		public event EventHandler Receive;

		/// <summary>
		/// This event is triggered when a sortable item has been dragged out from the list and into another.
		/// Reference: http://jqueryui.com/demos/sortable/#remove
		/// </summary>
		[WidgetEvent("remove")]
		[Category("Action")]
		[Description("This event is triggered when a sortable item has been dragged out from the list and into another.")]
		public event EventHandler Remove;

		#endregion

	}
}