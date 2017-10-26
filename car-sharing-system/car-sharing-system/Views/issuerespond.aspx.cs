using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Diagnostics;
using System.Web.Security;

namespace car_sharing_system.Views
{
    public partial class issuerespond : System.Web.UI.Page
    {
        protected int id;

        protected void Page_Load(object sender, EventArgs e) {
			// Admin permission check
			HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			if (!UserModel.isAdmin(authCookie)) {
				Response.Redirect("/dashboard/");
			}

			if (!string.IsNullOrEmpty(Request.QueryString["id"])) {
				int issueID = Convert.ToInt32(Request.QueryString["id"]);
				Issue currIssue = DatabaseReader.issueQuerySingle("issueID = '" + issueID + "'");
				if (currIssue != null) {
					User user = DatabaseReader.userQuerySingle("accountID = '" + currIssue.accountID + "'");
					usernamelabel.Text = user.fname + " " + user.lname;
					issuesubjectlabel.Text = currIssue.subject;
					issuedesclabel.Text = currIssue.description;
					issuedatelabel.Text = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(currIssue.submissionDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm");
				} else {
					issueFail.InnerText = "Issue not found.";
				}
				id = issueID;
			}
		}

		protected void respondIssue(object sender, EventArgs e) {
			if (description.Text.Equals(null)) {
                issueFail.InnerText = "Please fill response form.";
            }
            else {
				DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
				long currentUnixTime = (long)DateTime.UtcNow.Subtract(unixStart).TotalSeconds; // start time
				DatabaseReader.setIssueResponded(currentUnixTime, id.ToString());
                Response.Redirect("/dashboard/admin/issues/");
            } 
        }
    }
}