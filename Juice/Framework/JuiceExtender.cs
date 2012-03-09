using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Juice.Framework {

	public abstract class JuiceExtender : ExtenderControl, IWidget, IPostBackDataHandler {

		private Control _targetControl;
		private JuiceWidgetState _widgetState;

		protected JuiceExtender(String widgetName) {
			if(string.IsNullOrEmpty(widgetName)) {
				throw new ArgumentException("The parameter must not be empty", "widgetName");
			}
			WidgetName = widgetName;
			SetDefaultOptions();
		}

		private JuiceWidgetState WidgetState {
			get {
				if(_widgetState == null) {
					_widgetState = new JuiceWidgetState(this);
				}
				return _widgetState;
			}
		}

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
				return !Enabled;
			}
			set {
				Enabled = !value;
			}
		}

		/// <summary>
		/// Enables (true) or disables (false) the dialog.
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Enables (true) or disables (false) the widget.")]
		public bool Enabled {
			get {
				return (bool)(ViewState["Enabled"] ?? true);
			}
			set {
				ViewState["Enabled"] = value;
			}
		}

		[Browsable(false)]
		public string WidgetName { get; private set; }

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			// TODO: Throw if the target can't be found
			_targetControl = FindControl(TargetControlID);

			if(_targetControl == null) {
				throw new ArgumentNullException("_targetControl is null");
			}

			//System.Web.UI.HtmlControls.HtmlControl c;
			//c.Attributes

			WidgetState.SetWidgetNameOnTarget(_targetControl as IAttributeAccessor);
			WidgetState.AddPagePreRenderCompleteHandler();
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);

			if(_targetControl.Visible) {
				Page.RegisterRequiresPostBack(this);
				WidgetState.ParseEverything(_targetControl);
				WidgetState.EnsureCssLink();
			}
		}

		protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection) {
			WidgetState.LoadPostData(postDataKey, postCollection);
			return false;
		}

		protected virtual void RaisePostDataChangedEvent() { 	}

		protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl) {
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

		void IWidget.SaveWidgetOptions() {
			((IWidget)this).WidgetOptions = SaveOptionsAsDictionary();
		}

		IDictionary<string, object> IWidget.WidgetOptions { get; set; }

		#endregion

		#region IPostBackDataHandler implementation

		bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection) {
			return LoadPostData(postDataKey, postCollection);
		}

		void IPostBackDataHandler.RaisePostDataChangedEvent() {
			RaisePostDataChangedEvent();
		}

		#endregion

	}
}