using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mobile {
	public class Link : LinkBase {

		public Link() : base(null) { }

		protected override System.Web.UI.HtmlTextWriterTag TagKey { get { return System.Web.UI.HtmlTextWriterTag.A; } }

	}
}
