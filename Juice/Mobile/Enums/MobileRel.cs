using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Mobile {
	public enum MobileRel {
		None,
		/// <summary>
		/// Move one step back in history.
		/// </summary>
		Back,  
		/// <summary>
		/// Open link styled as dialog, not tracked in history.
		/// </summary>
		Dialog,
		/// <summary>
		/// Link to another domain.
		/// </summary>
		External,
		/// <summary>
		/// Show the corresponding popup.
		/// </summary>
		Popup
	}
}
