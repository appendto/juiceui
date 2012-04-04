using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Juice.Framework;
using Juice.Framework.TypeConverters;

namespace Juice {

	/// <summary>
	/// Extend a Control, WebControl or HtmlControl with the jQuery UI Dialog http://jqueryui.com/demos/dialog/
	/// </summary>
	[TargetControlType(typeof(Control))]
	[TargetControlType(typeof(WebControl))]
	[TargetControlType(typeof(HtmlControl))] // should be able to support any kind of content control
	[WidgetEvent("create")]
	[WidgetEvent("beforeClose")]
	[WidgetEvent("dragStart")]
	[WidgetEvent("focus")]
	[WidgetEvent("open")]
	[WidgetEvent("drag")]
	[WidgetEvent("dragStop")]
	[WidgetEvent("resizeStart")]
	[WidgetEvent("resize")]
	[WidgetEvent("resizeStop")]
	public class Dialog : JuiceExtender {

		public Dialog() : base("dialog") { }

		#region Widget Options

		/// <summary>
		/// When autoOpen is true the dialog will open automatically when dialog is called. If false it will stay hidden until .dialog("open") is called on it.
		/// Reference: http://jqueryui.com/demos/dialog/#autoOpen
		/// </summary>
		[WidgetOption("autoOpen", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("When autoOpen is true the dialog will open automatically when dialog is called. If false it will stay hidden until .dialog(\"open\") is called on it.")]
		public bool AutoOpen { get; set; }

		/// <summary>
		/// Specifies which buttons should be displayed on the dialog. The property key is the text of the button. The value is the callback function for when the button is clicked.  The context of the callback is the dialog element; if you need access to the button, it is available as the target of the event object.
		/// Reference: http://jqueryui.com/demos/dialog/#buttons
		/// </summary>
		[WidgetOption("buttons", "{}", Eval = true)]
		[TypeConverter(typeof(Framework.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{}")]
		[Description("Specifies which buttons should be displayed on the dialog. The property key is the text of the button. The value is the callback function for when the button is clicked.  The context of the callback is the dialog element; if you need access to the button, it is available as the target of the event object.")]
		public string Buttons { get; set; }

		/// <summary>
		/// Specifies whether the dialog should close when it has focus and the user presses the esacpe (ESC) key.
		/// Reference: http://jqueryui.com/demos/dialog/#closeOnEscape
		/// </summary>
		[WidgetOption("closeOnEscape", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Specifies whether the dialog should close when it has focus and the user presses the esacpe (ESC) key.")]
		public bool CloseOnEscape { get; set; }

		/// <summary>
		/// Specifies the text for the close button. Note that the close text is visibly hidden when using a standard theme.
		/// Reference: http://jqueryui.com/demos/dialog/#closeText
		/// </summary>
		[WidgetOption("closeText", "close")]
		[Category("Appearance")]
		[DefaultValue("close")]
		[Description("Specifies the text for the close button. Note that the close text is visibly hidden when using a standard theme.")]
		public string CloseText { get; set; }

		/// <summary>
		/// The specified class name(s) will be added to the dialog, for additional theming.
		/// Reference: http://jqueryui.com/demos/dialog/#dialogClass
		/// </summary>
		[WidgetOption("dialogClass", "")]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("The specified class name(s) will be added to the dialog, for additional theming.")]
		public string DialogClass { get; set; }

		/// <summary>
		/// If set to true, the dialog will be draggable will be draggable by the titlebar.
		/// Reference: http://jqueryui.com/demos/dialog/#draggable
		/// </summary>
		[WidgetOption("draggable", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to true, the dialog will be draggable will be draggable by the titlebar.")]
		public bool Draggable { get; set; }

		/// <summary>
		/// The height of the dialog, in pixels. Specifying 'auto' is also supported to make the dialog adjust based on its content.
		/// Reference: http://jqueryui.com/demos/dialog/#height
		/// </summary>
		[WidgetOption("height", 0)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue("auto")]
		[Description("The height of the dialog, in pixels. Specifying 'auto' is also supported to make the dialog adjust based on its content.")]
		public dynamic Height { get; set; }

		/// <summary>
		/// The effect to be used when the dialog is closed.
		/// Reference: http://jqueryui.com/demos/dialog/#hide
		/// </summary>
		[WidgetOption("hide", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The effect to be used when the dialog is closed.")]
		public string Hide { get; set; }

		/// <summary>
		/// The maximum height to which the dialog can be resized, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#maxHeight
		/// </summary>
		[WidgetOption("maxHeight", 0)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("The maximum height to which the dialog can be resized, in pixels.")]
		public dynamic MaxHeight { get; set; }

		/// <summary>
		/// The maximum width to which the dialog can be resized, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#maxWidth
		/// </summary>
		[WidgetOption("maxWidth", 0)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("The maximum width to which the dialog can be resized, in pixels.")]
		public dynamic MaxWidth { get; set; }

		/// <summary>
		/// The minimum height to which the dialog can be resized, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#minHeight
		/// </summary>
		[WidgetOption("minHeight", 150)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(150)]
		[Description("The minimum height to which the dialog can be resized, in pixels.")]
		public dynamic MinHeight { get; set; }

		/// <summary>
		/// The minimum width to which the dialog can be resized, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#minWidth
		/// </summary>
		[WidgetOption("minWidth", 150)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(150)]
		[Description("The minimum width to which the dialog can be resized, in pixels.")]
		public dynamic MinWidth { get; set; }

		/// <summary>
		/// If set to true, the dialog will have modal behavior; other items on the page will be disabled (i.e. cannot be interacted with). Modal dialogs create an overlay below the dialog but above other page elements.
		/// Reference: http://jqueryui.com/demos/dialog/#modal
		/// </summary>
		[WidgetOption("modal", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, the dialog will have modal behavior; other items on the page will be disabled (i.e. cannot be interacted with). Modal dialogs create an overlay below the dialog but above other page elements.")]
		public bool Modal { get; set; }

		/// <summary>
		/// Specifies where the dialog should be displayed. Possible values: 1) a single string representing position within viewport: 'center', 'left', 'right', 'top', 'bottom'. 2) an array containing an x,y coordinate pair in pixel offset from left, top corner of viewport (e.g. [350,100]) 3) an array containing x,y position string values (e.g. ['right','top'] for top right corner).
		/// Reference: http://jqueryui.com/demos/dialog/#position
		/// </summary>
		[WidgetOption("position", "center", Eval = true)]
		[TypeConverter(typeof(JsonObjectConverter))]
		[Category("Layout")]
		[DefaultValue("center")]
		[Description("Specifies where the dialog should be displayed. Possible values: 1) a single string representing position within viewport: 'center', 'left', 'right', 'top', 'bottom'. 2) an array containing an x,y coordinate pair in pixel offset from left, top corner of viewport (e.g. [350,100]) 3) an array containing x,y position string values (e.g. ['right','top'] for top right corner).")]
		public string Position { get; set; }

		/// <summary>
		/// If set to true, the dialog will be resizeable.
		/// Reference: http://jqueryui.com/demos/dialog/#resizable
		/// </summary>
		[WidgetOption("resizable", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to true, the dialog will be resizeable.")]
		public bool Resizable { get; set; }

		/// <summary>
		/// The effect to be used when the dialog is opened.
		/// Reference: http://jqueryui.com/demos/dialog/#show
		/// </summary>
		[WidgetOption("show", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("The effect to be used when the dialog is opened.")]
		public string Show { get; set; }

		/// <summary>
		/// Specifies whether the dialog will stack on top of other dialogs. This will cause the dialog to move to the front of other dialogs when it gains focus.
		/// Reference: http://jqueryui.com/demos/dialog/#stack
		/// </summary>
		[WidgetOption("stack", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Specifies whether the dialog will stack on top of other dialogs. This will cause the dialog to move to the front of other dialogs when it gains focus.")]
		public bool Stack { get; set; }

		/// <summary>
		/// Specifies the title of the dialog. Any valid HTML may be set as the title. The title can also be specified by the title attribute on the dialog source element.
		/// Reference: http://jqueryui.com/demos/dialog/#title
		/// </summary>
		[WidgetOption("title", "")]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("Specifies the title of the dialog. Any valid HTML may be set as the title. The title can also be specified by the title attribute on the dialog source element.")]
		public string Title { get; set; }

		/// <summary>
		/// The width of the dialog, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#width
		/// </summary>
		[WidgetOption("width", 300)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(300)]
		[Description("The width of the dialog, in pixels.")]
		public dynamic Width { get; set; }

		/// <summary>
		/// The starting z-index for the dialog.
		/// Reference: http://jqueryui.com/demos/dialog/#zIndex
		/// </summary>
		[WidgetOption("zIndex", 1000)]
		[Category("Behavior")]
		[DefaultValue(1000)]
		[Description("The starting z-index for the dialog.")]
		public int ZIndex { get; set; }

		#endregion

		#region Widget Events

		/// <summary>
		/// This event is triggered when the dialog is closed.
		/// Reference: http://jqueryui.com/demos/dialog/#close
		/// </summary>
		[WidgetEvent("close")]
		[Category("Action")]
		[Description("This event is triggered when the dialog is closed.")]
		public event EventHandler Close;

		#endregion

	}
}