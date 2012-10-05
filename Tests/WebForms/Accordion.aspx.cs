﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice_Sample_Site {
	public partial class Accordion : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

			var x = _Accordion.AccordionPanels[0].TemplateContainer.Controls.All().Where(c => c.ID == "dob1").FirstOrDefault();
			var y = _Accordion.AccordionPanels[0].FindControl("dob1");			
			
			_Postback.Click += delegate(object s, EventArgs ea) {
				var o = _Accordion.Animated;
			};
		}
	}
}