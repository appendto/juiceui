using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace Juice.Mvc {

	public partial class AccordionWidget {

		/// <summary>
		/// Creates and renders an AccordionPanel.
		/// </summary>
		/// <param name="header">The text that is displayed in the accordion header.</param>
		/// <returns></returns>
		//  public AccordionPanel AccordionPanel(String header) {
		//    return new AccordionPanel(this._helper, header);
		//  }
		//}

		//public class AccordionPanel : JuiceWidget<AccordionPanel>, IDisposable {

		//  private String _header = "Panel Header";

		//  public AccordionPanel(HtmlHelper helper, String header) : base(helper, null) {
		//    _header = header;
		//  }

		//  public override void Render() {

		//    _writer.RenderBeginTag(HtmlTextWriterTag.H3);
		//    _writer.Write(_header);
		//    _writer.RenderEndTag();

		//    _writer.RenderBeginTag(HtmlTextWriterTag.Div);

		//    if(_content != null) {

		//      System.Web.WebPages.HelperResult res = _content(this);
		//      _writer.Write(res.ToHtmlString());
		//    }

		//    _writer.RenderEndTag();

		//  }
		//}
	}
}
