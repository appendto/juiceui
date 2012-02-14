using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Juice_Sample_Site {
    public partial class UpdatePanel : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            // Setting this in code-behind to test ViewState persistence across postbacks.
            Age.Min = 13;
        }

        protected void FinalStep_Activated(object sender, EventArgs e) {
            PersistedMinValue.Text = Age.Value.ToString();
        }
    }
}