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
		/// <param name="elementId">Sets the id attribute of the rendered element.</param>
		/// <param name="corners">Applies the theme button border-radius if set to true.</param>,
		/// <param name="icon">Applies an icon from the icon set.</param>,
		/// <param name="iconpos">Positions the icon in the button. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.</param>,
		/// <param name="iconshadow">Applies the theme shadow to the button's icon if set to true.</param>,
		/// <param name="shadow">Applies the drop shadow style to the button if set to true.</param>,
		/// <param name="ajax">Use ajax to retrieve this link.</param>,
		/// <param name="direction">Reverse page transition animation.</param>,
		/// <param name="domCache">Apply dom-cache.</param>,
		/// <param name="inline">Inline link.</param>,
		/// <param name="prefetch">When using single-page templates, you can prefetch pages into the DOM so that they're available instantly when the user visits them.</param>,
		/// <param name="rel">How the link should behave, Back, Dialog, External, or Popup.</param>,
		/// <param name="transition">By default, the dialog will open with a 'pop' transition.</param>,
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>ButtonWidget</returns>
		public ButtonWidget Button(String elementId = "", Boolean corners = true, MobileIcon? icon = null, MobileIconPosition? iconpos = null, Boolean iconshadow = true, Boolean shadow = true, Boolean ajax = true, MobileDirection? direction = null, Boolean domCache = false, Boolean inline = false, Boolean prefetch = false, MobileRel? rel = null, MobileTransition? transition = null, Boolean mini = false, String theme = null) {
			var widget = new ButtonWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(corners, icon, iconpos, iconshadow, shadow, ajax, direction, domCache, inline, prefetch, rel, transition, mini, theme);

			return widget;
		}
	}

	public partial class ButtonWidget : JuiceMobileWidget<ButtonWidget>, IDisposable {

		public ButtonWidget(HtmlHelper helper) : base(helper, "button") {
			_optionsMap = new Dictionary<String, String> {
				{ "corners", "corners" },
				{ "icon", "icon" },
				{ "iconpos", "iconpos" },
				{ "iconshadow", "iconshadow" },
				{ "shadow", "shadow" },
				{ "ajax", "ajax" },
				{ "direction", "direction" },
				{ "domCache", "dom-cache" },
				{ "inline", "inline" },
				{ "prefetch", "prefetch" },
				{ "rel", "rel" },
				{ "transition", "transition" },
				{ "mini", "mini" },
				{ "theme", "theme" }
			};
		}

		public ButtonWidget Options(Boolean corners = true, MobileIcon? icon = null, MobileIconPosition? iconpos = null, Boolean iconshadow = true, Boolean shadow = true, Boolean ajax = true, MobileDirection? direction = null, Boolean domCache = false, Boolean inline = false, Boolean prefetch = false, MobileRel? rel = null, MobileTransition? transition = null, Boolean mini = false, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => corners),
				JuiceHelpers.GetMemberInfo(() => icon),
				JuiceHelpers.GetMemberInfo(() => iconpos),
				JuiceHelpers.GetMemberInfo(() => iconshadow),
				JuiceHelpers.GetMemberInfo(() => shadow),
				JuiceHelpers.GetMemberInfo(() => ajax),
				JuiceHelpers.GetMemberInfo(() => direction),
				JuiceHelpers.GetMemberInfo(() => domCache),
				JuiceHelpers.GetMemberInfo(() => inline),
				JuiceHelpers.GetMemberInfo(() => prefetch),
				JuiceHelpers.GetMemberInfo(() => rel),
				JuiceHelpers.GetMemberInfo(() => transition),
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

		internal override System.Web.UI.HtmlTextWriterTag Tag {
			get {
				return System.Web.UI.HtmlTextWriterTag.Button;
			}
		}

		public override void Render() {
			base.Render();
			base.RenderEnd();
		}
	}
}
