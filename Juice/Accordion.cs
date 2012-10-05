using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using Juice.Framework;
using Juice.Framework.TypeConverters;

namespace Juice {
	[PersistChildren(true)]
	[ParseChildren(typeof(AccordionPanel), DefaultProperty = "AccordionPanels", ChildrenAsProperties = true)]
	[WidgetEvent("create")]
	[WidgetEvent("beforeActivate")]
	public class Accordion : JuiceScriptControl, IAutoPostBackWidget {

		private List<AccordionPanel> _panels;

		public Accordion() : base("accordion") {
			this._panels = new List<AccordionPanel>();
		}

		#region Widget Options

		/// <summary>
		/// Selector for the active element. Set to false to display none at start. Needs collapsible: true.
		/// Reference: http://api.jqueryui.com/accordion/#option-active
		/// </summary>
		[WidgetOption("active", "0")]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue("0")]
		[Description("Selector for the active element. Set to false to display none at start. Needs collapsible: true.")]
		public dynamic Active { get; set; }

		/// <summary>
		/// Choose your favorite animation, or disable them (set to false). In addition to the default, 'bounceslide' and all defined easing methods are supported ('bounceslide' requires UI Effects Core).
		/// Reference: http://api.jqueryui.com/accordion/#option-animated
		/// </summary>
		[WidgetOption("animate", "{}", Eval = true)]
		[TypeConverter(typeof(Framework.TypeConverters.JsonObjectConverter))]
		[Category("Behavior")]
		[DefaultValue("{}")]
		[Description("Choose your favorite animation, or disable them (set to false). In addition to the default, 'bounceslide' and all defined easing methods are supported ('bounceslide' requires UI Effects Core).")]
		public string Animate { get; set; }
		
		/// <summary>
		/// Whether all the sections can be closed at once. Allows collapsing the active section by the triggering event (click is the default).
		/// Reference: http://api.jqueryui.com/accordion/#option-collapsible
		/// </summary>
		[WidgetOption("collapsible", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Whether all the sections can be closed at once. Allows collapsing the active section by the triggering event (click is the default).")]
		public bool Collapsible { get; set; }

		/// <summary>
		/// The event on which to trigger the accordion.
		/// Reference: http://api.jqueryui.com/accordion/#option-event
		/// </summary>
		[WidgetOption("event", "click")]
		[Category("Behavior")]
		[DefaultValue("click")]
		[Description("The event on which to trigger the accordion.")]
		public string Event { get; set; }

		/// <summary>
		/// Selector for the header element.
		/// Reference: http://api.jqueryui.com/accordion/#option-header
		/// </summary>
		[WidgetOption("header", "> li > :first-child,> :not(li):even")]
		[Category("Layout")]
		[DefaultValue("> li > :first-child,> :not(li):even")]
		[Description("Selector for the header element.")]
		public string Header { get; set; }

		/// <summary>
		/// Controls the height of the accordion and each panel. Possible values: 
		/// "auto": All panels will be set to the height of the tallest panel. 
		/// "fill": Expand to the available height based on the accordion's parent height. 
		/// "content": Each panel will be only as tall as its content.
		/// Reference: http://api.jqueryui.com/accordion/#option-heightstyle
		/// </summary>
		[WidgetOption("heightStyle", "{}", Eval = true)]
		[TypeConverter(typeof(Framework.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{}")]
		[Description(@"Controls the height of the accordion and each panel. Possible values: 
""auto"": All panels will be set to the height of the tallest panel. 
""fill"": Expand to the available height based on the accordion's parent height. 
""content"": Each panel will be only as tall as its content.")]
		public string HeightStyle { get; set; }

		/// <summary>
		/// Icons to use for headers. Icons may be specified for 'header' and 'headerSelected', and we recommend using the icons native to the jQuery UI CSS Framework manipulated by jQuery UI ThemeRoller
		/// Reference: http://api.jqueryui.com/accordion/#option-icons
		/// </summary>
		[WidgetOption("icons", "{}", Eval = true)]
		[TypeConverter(typeof(Framework.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{}")]
		[Description("Icons to use for headers. Icons may be specified for 'header' and 'headerSelected', and we recommend using the icons native to the jQuery UI CSS Framework manipulated by jQuery UI ThemeRoller")]
		public string Icons { get; set; }

		/// <summary>
		/// If set, looks for the anchor that matches location.href and activates it. Great for href-based state-saving. Use navigationFilter to implement your own matcher.
		/// Reference: http://api.jqueryui.com/accordion/#option-navigation
		/// </summary>
		[Obsolete("This option will be removed in jQuery UI 1.10.")]
		public bool Navigation { get; set; }

		/// <summary>
		/// Overwrite the default location.href-matching with your own matcher.
		/// Reference: http://api.jqueryui.com/accordion/#option-navigationFilter
		/// </summary>
		[Obsolete("This option will be removed in jQuery UI 1.10.")]
		public string NavigationFilter { get; set; }

		#endregion

		#region Obsolete Widget Options

		[Obsolete("This property has been deprecated in jQuery UI 1.9. Use Animate instead.", true)]
		public string Animated { get; set; }

		[Obsolete("This property has been deprecated in jQuery UI 1.9. Use HeightStyle instead.", true)]
		public bool AutoHeight { get; set; }

		[Obsolete("This property has been deprecated in jQuery UI 1.9. Use HeightStyle instead.", true)]
		public bool ClearStyle { get; set; }

		[Obsolete("This property has been deprecated in jQuery UI 1.9. Use HeightStyle instead.", true)]
		public bool FillSpace { get; set; }

		#endregion

		#region Widget Events

		/// <summary>
		/// This event is triggered every time the accordion changes. If the accordion is animated, the event will be triggered upon completion of the animation; otherwise, it is triggered immediately.
		/// 
		/// Reference: http://api.jqueryui.com/accordion/#event-activate
		/// </summary>
		[WidgetEvent("activate", AutoPostBack = true)]
		[Category("Action")]
		[Description("This event is triggered when an accordion panel is shown.")]
		public event EventHandler PanelActivated;		
		
		[Obsolete("This event has been deprecated in jQuery UI 1.9. Use PanelActivated instead.", true)]
		public event EventHandler SelectedPanelChanged;

		#endregion

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public List<AccordionPanel> AccordionPanels { 
			get { return this._panels;  }

		}

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Div;
			}
		}

		public override ControlCollection Controls {
			get {
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		protected override void OnPreRender(EventArgs e) {

			this.Controls.Clear();

			if(AccordionPanels != null) {
				foreach(AccordionPanel panel in AccordionPanels) {
					this.Controls.Add(panel);
				}
			}

			base.OnPreRender(e);
		}

	}
}
