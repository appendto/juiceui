using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;

using Juice.Framework;
using Juice.Framework.TypeConverters;

namespace Juice {

	/// <summary>
	/// Extend a WebControl or HtmlControl with jQuery UI Droppable http://api.jqueryui.com/droppable
	/// </summary>
	[TargetControlType(typeof(WebControl))]
	[TargetControlType(typeof(HtmlControl))]
	[WidgetEvent("create")]
	[WidgetEvent("activate")]
	[WidgetEvent("deactivate")]
	[WidgetEvent("over")]
	[WidgetEvent("out")]
	public class Droppable : JuiceExtender, IAutoPostBackWidget {

		public Droppable() : base("droppable") { }

    #region Widget Options

    /// <summary>
    /// All draggables that match the selector will be accepted. If a function is specified, the function will be called for each draggable on the page (passed as the first argument to the function), to provide a custom filter. The function should return true if the draggable should be accepted.
    /// Reference: http://api.jqueryui.com/droppable/#option-accept
    /// </summary>
    [WidgetOption("accept", "*")]
		[Category("Behavior")]
		[DefaultValue("*")]
		[Description("All draggables that match the selector will be accepted. If a function is specified, the function will be called for each draggable on the page (passed as the first argument to the function), to provide a custom filter. The function should return true if the draggable should be accepted.")]
    public string Accept { get; set; }

    /// <summary>
    /// If specified, the class will be added to the droppable while an acceptable draggable is being dragged.
    /// Reference: http://api.jqueryui.com/droppable/#option-activeClass
    /// </summary>
    [WidgetOption("activeClass", false)]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("If specified, the class will be added to the droppable while an acceptable draggable is being dragged.")]
		[TypeConverter(typeof(StringToObjectConverter))]
    public dynamic ActiveClass { get; set; }

    /// <summary>
    /// If set to false, will prevent the ui-droppable class from being added. This may be desired as a performance optimization when calling .droppable() init on many hundreds of elements.
    /// Reference: http://api.jqueryui.com/droppable/#option-addClasses
    /// </summary>
    [WidgetOption("addClasses", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to false, will prevent the ui-droppable class from being added. This may be desired as a performance optimization when calling .droppable() init on many hundreds of elements.")]
    public bool AddClasses { get; set; }

    /// <summary>
    /// If true, will prevent event propagation on nested droppables.
    /// Reference: http://api.jqueryui.com/droppable/#option-greedy
    /// </summary>
    [WidgetOption("greedy", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If true, will prevent event propagation on nested droppables.")]
    public bool Greedy { get; set; }

    /// <summary>
    /// If specified, the class will be added to the droppable while an acceptable draggable is being hovered.
    /// Reference: http://api.jqueryui.com/droppable/#option-hoverClass
    /// </summary>
    [WidgetOption("hoverClass", false)]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("If specified, the class will be added to the droppable while an acceptable draggable is being hovered.")]
		[TypeConverter(typeof(StringToObjectConverter))]
    public dynamic HoverClass { get; set; }

    /// <summary>
    /// Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted.
    /// Reference: http://api.jqueryui.com/droppable/#option-scope
    /// </summary>
    [WidgetOption("scope", "default")]
		[Category("Behavior")]
		[DefaultValue("default")]
		[Description("Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted.")]
    public string Scope { get; set; }

    /// <summary>
    /// Specifies which mode to use for testing whether a draggable is 'over' a droppable. Possible values: 'fit', 'intersect', 'pointer', 'touch'.
    /// Reference: http://api.jqueryui.com/droppable/#option-tolerance
    /// </summary>
    [WidgetOption("tolerance", "intersect")]
		[Category("Behavior")]
		[DefaultValue("intersect")]
		[Description("Specifies which mode to use for testing whether a draggable is 'over' a droppable. Possible values: 'fit', 'intersect', 'pointer', 'touch'.")]
    public string Tolerance { get; set; }

    #endregion

		#region Widget Events

		/// <summary>
		/// This event is triggered when an accepted draggable is dropped 'over' (within the tolerance of) this droppable. In the callback, $(this) represents the droppable the draggable is dropped on.
		/// ui.draggable represents the draggable.
		/// Reference: http://api.jqueryui.com/droppable/#event-drop
		/// </summary>
		[WidgetEvent("drop", AutoPostBack = true)]
		[Category("Action")]
		[Description("This event is triggered when an accepted draggable is dropped 'over' (within the tolerance of) this droppable. In the callback, $(this) represents the droppable the draggable is dropped on.")]
		public event EventHandler Drop;

		#endregion

	}
}