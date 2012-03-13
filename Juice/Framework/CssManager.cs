using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Juice.Framework {
	public class CssManager {

		private Control _control;
		private ScriptManager _scriptManager;
		private Boolean? _isSecureConnection;
		private static CssResourceMapping _cssResourceMapping;

		public CssManager(Control control) {
			_control = control;
		}

		private Page Page { get { return _control.Page; } }

		private ScriptManager ScriptManager {
			get {
				if(_scriptManager == null) {
					_scriptManager = ScriptManager.GetCurrent(this.Page);
				}

				return _scriptManager;
			}
		}

		/// <summary>
		/// Renders the appropriate CSS links as defined and references.
		/// </summary>
		/// <param name="referenceNames"></param>
		public void Render(IEnumerable<String> referenceNames){

			if(Page.Header == null) {
				throw new InvalidOperationException("The Page or MasterPage must contain a HEAD tag with the 'runat=\"server\"' attribute.");
			}

			Control container = Page.Header.Controls.All().Where(c => c is CssPlaceholder).SingleOrDefault() ?? Page.Header;

			foreach(String reference in referenceNames) {

				String linkId = String.Concat("juice_", reference);

				if(container.FindControl(linkId) != null) {
					continue;
				}

				CssResourceDefinition defintion = CssManager.CssResourceMapping.GetDefinition(reference);
				String url = GetUrl(defintion);

				if(String.IsNullOrEmpty(url)) { // we have a ton of checks in place before we get here. if something went wrong, just continue;
					continue;
				}

				HtmlLink link = new HtmlLink {
					ClientIDMode = ClientIDMode.Static,
					ID = linkId,
					Href = url
				};

				link.Attributes.Add("type", "text/css");
				link.Attributes.Add("rel", "stylesheet");

				container.Controls.Add(link);
			}
		}

		public String GetUrl(CssResourceDefinition defintion) {

			String path = null;

			if(this.EnableCDN) {
				path = IsDebuggingEnabled ? defintion.CdnDebugPath : defintion.CdnPath;

				if(String.IsNullOrEmpty(path)) {
					path = defintion.CdnPath;
				}
			}

			if(String.IsNullOrEmpty(path)) {
				path = IsDebuggingEnabled ? defintion.DebugPath : defintion.Path;

				if(String.IsNullOrEmpty(path)) {
					path = defintion.Path;
				}

				path = Page.ResolveUrl(path);
			}

			return path;
		}

		public Boolean IsDebuggingEnabled { get { return this.ScriptManager.IsDebuggingEnabled; } }

		public Boolean EnableCDN { get { return this.ScriptManager.EnableCdn; } }

		internal Boolean IsSecureConnection {
			get {
				if(!this._isSecureConnection.HasValue) {
					HttpContext context = HttpContext.Current;

					if(context == null) {
						return false;
					}

					this._isSecureConnection = new Boolean?(((context != null) && (context.Request != null)) && context.Request.IsSecureConnection);
				}
				return this._isSecureConnection.Value;
			}
		}

		public static CssResourceMapping CssResourceMapping {
			get {
				if(_cssResourceMapping == null) {
					_cssResourceMapping = new CssResourceMapping();
				}

				return _cssResourceMapping;
			}
		}

	}
}
