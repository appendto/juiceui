using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Juice.Mvc {
	public partial class JuiceHelpers {

		private Mobile.MobileHelpers _mobileHelpers = null;

		public Mobile.MobileHelpers Mobile {
			get {
				if(_mobileHelpers == null) {
					_mobileHelpers = new Mobile.MobileHelpers(_helper);
				}

				return _mobileHelpers;
			}
		}

	}
}

namespace Juice.Mvc.Mobile {
	
	public partial class MobileHelpers {

		protected HtmlHelper _helper;

		public HtmlHelper Helper { get { return _helper; } }

		public MobileHelpers(HtmlHelper helper) {
			_helper = helper;
		}

	}
}
