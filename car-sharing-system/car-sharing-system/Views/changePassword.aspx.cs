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
			String nPass = new User().hashMe(newPassword.Value);
			String cPass = new User().hashMe(currPassword.Value);

			Debug.WriteLine(nPass);
			Debug.WriteLine(cPass);
			Debug.WriteLine(currUser.password);

			if (cPass == currUser.password) {
				currUser.changePassword(nPass);
				DatabaseReader.changePassword(currUser);
				Response.Redirect("/dashboard/profile");
			} else {
				FailureText.Text = "Current password is wrong.";
			}

		}
	}
}