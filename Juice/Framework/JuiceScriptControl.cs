using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Juice.Framework {

	public abstract class JuiceScriptControl : ScriptControl, IWidget, IPostBackDataHandler {

		private JuiceWidgetState _widgetState;

		private JuiceWidgetState WidgetState {
			get {
				if(_widgetState == null) {
					_widgetState = new JuiceWidgetState(this);
				}
				return _widgetState;
			}
		}

		protected JuiceScriptControl(string widgetName) {
			if(string.IsNullOrEmpty(widgetName)) {
				throw new ArgumentException("The parameter must not be empty", "widgetName");
			}
			WidgetName = widgetName;
			//update by c1
			//WidgetState.SetDefaultOptions();
			SetDefaultOptions();
			//end by c1
		}

		/// <summary>
		/// Disables (true) or enables (false) the widget.
		/// </summary>
		[WidgetOption("disabled", false)] // every widget has a disabled option.
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Disabled {
			get {
				return !Enabled;
			}
			set {
				Enabled = !value;
			}
		}

		[Browsable(false)]
		public string WidgetName {
			get;
			private set;
		}

		#region Hide inherited inline style properties

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
				WidgetState.EnsureCssLink();
			}
		}

		protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection) {
			WidgetState.LoadPostData(postDataKey, postCollection);
			return false;
		}

		protected virtual void RaisePostDataChangedEvent() {

		}

		protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors() {
			return null;
		}

		protected override IEnumerable<ScriptReference> GetScriptReferences() {
			return WidgetState.GetJuiceReferences();
		}

		#region IWidget implementation
		Page IWidget.Page {
			get {
				return Page;
			}
		}

		string IWidget.ClientID {
			get {
				return ClientID;
			}
		}

		string IWidget.UniqueID {
			get {
				return UniqueID;
			}
		}

		bool IWidget.Visible {
			get {
				return Visible;
			}
		}

		//Add by c1
		void IWidget.SaveWidgetOptions() {
			((IWidget)this).WidgetOptions = SaveOptionsAsDictionary();
		}

		IDictionary<string, object> IWidget.WidgetOptions { get; set; }
		//end by c1
		#endregion

		#region IPostBackDataHandler implementation
		bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection) {
			return LoadPostData(postDataKey, postCollection);
		}

		void IPostBackDataHandler.RaisePostDataChangedEvent() {
			RaisePostDataChangedEvent();
		}
		#endregion

		//update by c1
		protected virtual IDictionary<string, object> SaveOptionsAsDictionary() {
			return WidgetState.ParseOptions();
		}

		protected virtual void SetDefaultOptions() {
			WidgetState.SetDefaultOptions();
		}
		//end by c1
	}
}