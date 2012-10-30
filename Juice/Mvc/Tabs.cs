using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.WebPages;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Tabs if set to true.</param>
		/// <param name="active">Which panel is currently open.</param>
		/// <param name="collapsible">When set to true, the active panel can be closed.</param>
		/// <param name="event">The type of event that the tabs should react to in order to activate the tab. To activate on hover, use "mouseover".</param>
		/// <param name="heightStyle">Controls the height of the tabs widget and each panel. Possible values: "auto", "fill", "content"</param>
		/// <param name="hide">If and how to animate the hiding of the panel.</param>
		/// <param name="show">If and how to animate the showing of the panel.</param>
		/// <returns>TabsWidget</returns>
		public TabsWidget Tabs(String elementId = "", String target = "", Boolean disabled = false,
			dynamic active = null,
			Boolean collapsible = false,
			String @event = "click",
			String heightStyle = "content",
			dynamic hide = null,
			dynamic show = null	
			) {
			var widget = new TabsWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled, 
				active,
				collapsible,
				@event,
				heightStyle,
				hide,
				show);

			return widget;
		}

	}

	public partial class TabsWidget : JuiceWidget<TabsWidget>, IDisposable {

		public class TabPanel {

			public String Header { get; set; }
			public String PanelId { get; set; }
			public Func<TabPanel, HelperResult> Content { get; set; }

			public void Render(HtmlTextWriter writer) {

				//<li><a href="#fragment-1"><span>One</span></a></li>

				writer.RenderBeginTag(HtmlTextWriterTag.Li);

				writer.AddAttribute("href", "#" + PanelId);
				writer.RenderBeginTag(HtmlTextWriterTag.A);

				writer.RenderBeginTag(HtmlTextWriterTag.Span);
				writer.Write(Header);

				writer.RenderEndTag();		
				writer.RenderEndTag();
				writer.RenderEndTag();
				
			}

			public void RenderPanel(HtmlTextWriter writer) {
				writer.AddAttribute("id", PanelId);
				writer.RenderBeginTag(HtmlTextWriterTag.Div);

				if(Content != null) {

					System.Web.WebPages.HelperResult res = Content(this);
					writer.Write(res.ToHtmlString());
				}

				writer.RenderEndTag();
			}

		}

		private List<TabPanel> _tabs = new List<TabPanel>();

		public TabsWidget(HtmlHelper helper) : base(helper, "tabs") { }

		public TabsWidget Options(Boolean disabled = false, 
				dynamic active = null,
				Boolean collapsible = false,
				String @event = "click",
				String heightStyle = "content",
				dynamic hide = null,
				dynamic show = null	
			) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => active),
				JuiceHelpers.GetMemberInfo(() => collapsible),
				JuiceHelpers.GetMemberInfo(() => @event),
				JuiceHelpers.GetMemberInfo(() => heightStyle),
				JuiceHelpers.GetMemberInfo(() => hide),
				JuiceHelpers.GetMemberInfo(() => show)
			);

			return this;
		}
		
		/// <summary>
		/// Adds a tab to the TabWidget. Use TabPanel to add panels to the TabWidget.
		/// </summary>
		/// <param name="header">The text displayed in the tab.</param>
		/// <param name="panelId">The ID of the panel the tab should activate. This should match the panelId parameter in the TabPabel method.</param>
		/// <returns></returns>
		public TabsWidget AddTab(String header, String panelId, Func<TabPanel, HelperResult> content = null) {
			_tabs.Add(new TabPanel() { Header = header, PanelId = panelId, Content = content });
			return this;
		}

		public override void RenderStart() {
			base.RenderStart();

			// render the UL that holds the tabs
			_writer.RenderBeginTag(HtmlTextWriterTag.Ul);

			_tabs.ForEach(t => t.Render(_writer));
			
			_writer.RenderEndTag();

			_tabs.ForEach(t => t.RenderPanel(_writer));

			//_panels.ForEach(t => t.Render());
		}

	}
}
