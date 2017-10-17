using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using car_sharing_system.Models;

namespace car_sharing_system.Views {
	public partial class changePassword : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void submit(object sender, EventArgs e) {
			// Get user's email from database
			User currUser = DatabaseReader.userQuerySingle("accountID = '" + User.Identity.Name + "'");
			String password = new User().hashMe(newPassword.Value);
			// Have to re-access database due to different hash value stored
			// in currUser (weird)
			User myData = UserModel.loginAttempt(currUser.email, password);
			if (myData != null) {
				// change password
			} else {
				// Return to page with error message
			}

		}
	}
}