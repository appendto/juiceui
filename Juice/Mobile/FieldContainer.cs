using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {

	//Container with data-role="fieldcontain" wrapped around label/form element pair
	[ParseChildren(false)]
	public class FieldContainer : Juice.Mobile.Framework.MobileControlBase {

		public FieldContainer() : base("fieldcontain") { }
	}
}
