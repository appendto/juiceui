using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Juice.Mobile.Framework {
	public interface IMobileControl {

		String Role { get; }
		Control TargetControl { get; }

	}
}
