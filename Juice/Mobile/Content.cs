using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Juice.Mobile {

	//Container with data-role="content"
	[ParseChildren(false)]
	public class Content : ThemeControlBase {

		public Content() : base("content") { }

	}
}
