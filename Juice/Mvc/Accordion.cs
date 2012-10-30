using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.WebPages;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Convert a pair of headers and content panels into an accordion.
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Accordion if set to true.</param>
		/// <param name="active">Which panel is currently open. Setting active to false will collapse all panels. Setting to a zero-based index will option the specified panel.</param>
		/// <param name="animate">If and how to animate changing panels.</param>
		/// <param name="collapsible">Whether all the sections can be closed at once. Allows collapsing the active section.</param>
		/// <param name="event">The event that accordion headers will react to in order to activate the associated panel. Multiple events can be specificed, separated by a space.</param>
		/// <param name="header">Selector for the header element, applied via .find() on the main accordion element. Content panels must be the sibling immedately after their associated headers.</param>
		/// <param name="heightStyle">Controls the height of the accordion and each panel. Possible values: "auto", "fill", "content"</param>
		/// <param name="icons">Icons to use for headers, matching an icon defined by the jQuery UI CSS Framework. Set to false to have no icons displayed.</param>
		/// <returns></returns>
		public AccordionWidget Accordion(String elementId = "", String target = "", Boolean disabled = false,
				dynamic active = null,
				dynamic animate = null,
				Boolean collapsible = false,
				String @event = "click",
				String header = "> li > :first-child,> :not(li):even",
				String heightStyle = "auto",
				AccordionIcons icons = null			
			) {
			var widget = new AccordionWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled, 
				active,
				animate,
				collapsible,
				@event,
				header,
				heightStyle,
				icons);

			return widget;
		}

	}

	public partial class AccordionWidget : JuiceWidget<AccordionWidget>, IDisposable {

		public class AccordionPanel {

			public String Header { get; set; }
			public Func<AccordionPanel, HelperResult> Content { get; set; }

			public void Render(HtmlTextWriter writer) {

				writer.RenderBeginTag(HtmlTextWriterTag.H3);
				writer.Write(Header);
				writer.RenderEndTag();

				writer.RenderBeginTag(HtmlTextWriterTag.Div);

				if(Content != null) {

					HelperResult res = Content(this);
					writer.Write(res.ToHtmlString());
				}

				writer.RenderEndTag();

			}

		}

		private List<AccordionPanel> _panels = new List<AccordionPanel>();

		public AccordionWidget(HtmlHelper helper) : base(helper, "accordion") { }

		public AccordionWidget Options(Boolean disabled = false, dynamic active = null,
				dynamic animate = null,
				Boolean collapsible = false,
				String @event = "click",
				String header = "> li > :first-child,> :not(li):even",
				String heightStyle = "auto",
				AccordionIcons icons = null
			) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => active),
				JuiceHelpers.GetMemberInfo(() => animate),
				JuiceHelpers.GetMemberInfo(() => collapsible),
				JuiceHelpers.GetMemberInfo(() => @event),
				JuiceHelpers.GetMemberInfo(() => header),
				JuiceHelpers.GetMemberInfo(() => heightStyle),
				JuiceHelpers.GetMemberInfo(() => icons)
			);

			return this;
		}

		/// <summary>
		/// Adds a tab to the TabWidget. Use TabPanel to add panels to the TabWidget.
		/// </summary>
		/// <param name="header">The text displayed in the tab.</param>
		/// <param name="panelId">The ID of the panel the tab should activate. This should match the panelId parameter in the TabPabel method.</param>
		/// <returns></returns>
		public AccordionWidget AddPanel(String header, Func<AccordionPanel, HelperResult> content = null) {
			_panels.Add(new AccordionPanel() { Header = header, Content = content });
			return this;
		}

		public override void RenderStart() {
			base.RenderStart();

			_panels.ForEach(t => t.Render(_writer));
		}

	}
}
