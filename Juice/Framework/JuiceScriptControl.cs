using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Juice.Framework {

	public abstract class JuiceScriptControl : ScriptControl, IWidget, IPostBackDataHandler, IPostBackEventHandler {

		private JuiceWidgetState _widgetState;
		private String _widgetName;

		protected JuiceScriptControl(string widgetName) {
			if(string.IsNullOrEmpty(widgetName)) {
				throw new ArgumentException("The parameter must not be empty", "widgetName");
			}
			
			_widgetName = widgetName;
			_widgetState = new JuiceWidgetState(this);

			SetDefaultOptions();
		}

		[Browsable(false)]
		private JuiceWidgetState WidgetState { get { return this._widgetState; } }

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			WidgetState.SetWidgetNameOnTarget(this);
			WidgetState.AddPagePreRenderCompleteHandler();
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);

			if(Visible) {
				Page.RegisterRequiresPostBack(this);
				WidgetState.ParseEverything(this);
				WidgetState.RenderCss();
			}
		}

		protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection) {
			WidgetState.LoadPostData();
			return false;
		}

		protected virtual void RaisePostDataChangedEvent() { }

		protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors() {
			return null;
		}

		protected override IEnumerable<ScriptReference> GetScriptReferences() {
			return WidgetState.GetJuiceReferences();
		}

		protected virtual IDictionary<string, object> SaveOptionsAsDictionary() {
			return WidgetState.ParseOptions();
		}

		protected virtual void SetDefaultOptions() {
			WidgetState.SetDefaultOptions();
		}

		#region IWidget Implementation

		/// <summary>
		/// Disables (true) or enables (false) the widget.
		/// </summary>
		[WidgetOption("disabled", false)] // every widget has a disabled option.
		[Browsable(false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Disables (true) or enables (false) the widget.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Disabled {
			get {
				return (bool)(ViewState["Disabled"] ?? false);
			}
			set {
				ViewState["Disabled"] = value;
			}
		}

		/// <summary>
		/// True, if the control should automatically postback to the server after the selected value is changed. False, otherwise.
		/// </summary>
		[DefaultValue(false)]
		[Description("True, if the control should automatically postback to the server after the selected value is changed. False, otherwise.")]
		[Category("Behavior")]
		public bool AutoPostBack {
			get {
				return (bool)(ViewState["AutoPostBack"] ?? false);
			}
			set {
				ViewState["AutoPostBack"] = value;
			}
		}

		/// <summary>
		/// The jQuery UI name of the widget.
		/// </summary>
		[Browsable(false)]
		public string WidgetName { get { return this._widgetName; } }

		Page IWidget.Page { get { return Page; } }

		string IWidget.ClientID { get { return ClientID; } }

		string IWidget.UniqueID { get { return UniqueID; } }

		bool IWidget.Visible { get { return Visible; } }

		void IWidget.SaveWidgetOptions() {
			((IWidget)this).WidgetOptions = SaveOptionsAsDictionary();
		}

		IDictionary<string, object> IWidget.WidgetOptions { get; set; }

		#endregion

		#region IPostBackDataHandler Implementation

		bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection) {
			return LoadPostData(postDataKey, postCollection);
		}

		void IPostBackDataHandler.RaisePostDataChangedEvent() {
			RaisePostDataChangedEvent();
		}

		#endregion

		#region IPostBackEventHandler Implementation

		void IPostBackEventHandler.RaisePostBackEvent(string eventArgument) {
			WidgetState.RaisePostBackEvent(eventArgument);
		}

		#endregion

		#region Hide inherited inline style properties - keep this at the bottom, out of the way

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Color BackColor {
			get {
				return base.BackColor;
			}
			set {
				base.BackColor = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Color BorderColor {
			get {
				return base.BorderColor;
			}
			set {
				base.BorderColor = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override BorderStyle BorderStyle {
			get {
				return base.BorderStyle;
			}
			set {
				base.BorderStyle = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Unit BorderWidth {
			get {
				return base.BorderWidth;
			}
			set {
				base.BorderWidth = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override FontInfo Font {
			get {
				return base.Font;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Color ForeColor {
			get {
				return base.ForeColor;
			}
			set {
				base.ForeColor = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Unit Height {
			get {
				return base.Height;
			}
			set {
				base.Height = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Unit Width {
			get {
				return base.Width;
			}
			set {
				base.Width = value;
			}
		}

		#endregion

	}
}