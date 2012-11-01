using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

using Juice.Mobile;

namespace Juice.Mvc.Mobile {

	public partial class MobileHelpers {

		/// <summary>
		/// {summary}
		/// </summary>
		/// <param name="positionTo">Centers the popup over the link that opens it, or the specific element.</param>,
		/// <param name="rel">Defines the behavior of the Anchor.</param>,
		/// <param name="icon">Applies an icon from the icon set.</param>,
		/// <param name="iconpos">Positions the icon in the anchor. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.</param>,
		/// <param name="ajax">Use ajax to retrieve this link.</param>,
		/// <param name="direction">Reverse page transition animation.</param>,
		/// <param name="domCache">Apply dom-cache.</param>,
		/// <param name="inline">Inline link.</param>,
		/// <param name="prefetch">When using single-page templates, you can prefetch pages into the DOM so that they're available instantly when the user visits them.</param>,
		/// <param name="transition">By default, the dialog will open with a 'pop' transition.</param>,
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>PopupAnchorWidget</returns>
		public PopupAnchorWidget PopupAnchor(String elementId = "", String href = "", String positionTo = "origin", MobileIcon? icon = null, MobileIconPosition? iconpos = null, Boolean ajax = true, MobileDirection? direction = null, Boolean domCache = false, Boolean inline = false, Boolean prefetch = false, MobileTransition? transition = null, Boolean mini = false, String theme = null) {
			var widget = new PopupAnchorWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(href, positionTo, MobileRel.Popup, icon, iconpos, ajax, direction, domCache, inline, prefetch, transition, mini, theme);

			return widget;
		}

	}

	public class PopupAnchorWidget : JuiceMobileWidget<PopupAnchorWidget>, IDisposable {

		public PopupAnchorWidget(HtmlHelper helper) : base(helper, "button") {
			_optionsMap = new Dictionary<String, String> {
				{ "positionTo", "position-to" },
				{ "rel", "rel" },
				{ "icon", "icon" },
				{ "iconpos", "iconpos" },
				{ "ajax", "ajax" },
				{ "direction", "direction" },
				{ "domCache", "dom-cache" },
				{ "inline", "inline" },
				{ "prefetch", "prefetch" },
				{ "transition", "transition" },
				{ "mini", "mini" },
				{ "theme", "theme" }
			};
		}

		public PopupAnchorWidget Options(String href = "", String positionTo = "origin", MobileRel? rel = null, MobileIcon? icon = null, MobileIconPosition? iconpos = null, Boolean ajax = true, MobileDirection? direction = null, Boolean domCache = false, Boolean inline = false, Boolean prefetch = false, MobileTransition? transition = null, Boolean mini = false, String theme = null) {

			this.AddAttribute("href", href);
			
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => positionTo),
				JuiceHelpers.GetMemberInfo(() => rel),
				JuiceHelpers.GetMemberInfo(() => icon),
				JuiceHelpers.GetMemberInfo(() => iconpos),
				JuiceHelpers.GetMemberInfo(() => ajax),
				JuiceHelpers.GetMemberInfo(() => direction),
				JuiceHelpers.GetMemberInfo(() => domCache),
				JuiceHelpers.GetMemberInfo(() => inline),
				JuiceHelpers.GetMemberInfo(() => prefetch),
				JuiceHelpers.GetMemberInfo(() => transition),
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

		internal override System.Web.UI.HtmlTextWriterTag Tag {
			get {
				return System.Web.UI.HtmlTextWriterTag.A;
			}
		}

		public override void Render() {
			base.Render();
			base.RenderEnd();
		}
	}
}
