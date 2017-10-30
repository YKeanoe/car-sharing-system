using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Web.Security;
using car_sharing_system.Models;

namespace car_sharing_system {
	public partial class Dashboard : System.Web.UI.MasterPage {

		protected void Page_Init(object sender, EventArgs e) {
			String path = HttpContext.Current.Request.Url.AbsolutePath;
			// If the page is not login page
			if (!path.Equals("/dashboard/login")) {
				// If the page is booking confirmation page
				if (path.Equals("/dashboard/confirmation")) {
					if (!Request.IsAuthenticated) {
						String id = Request.QueryString["id"];
						int sdate = Int32.Parse(Request.QueryString["sdate"]);
						int edate = Int32.Parse(Request.QueryString["edate"]);
						Response.Redirect("/dashboard/login?redirect=" + path + "&id=" + id + "&sdate=" + sdate + "&edate=" + edate);
					}
				} else if (path.Equals("/dashboard/register")) {
					// Do nothing.
				} else {
					if (!Request.IsAuthenticated) {
						Response.Redirect("/dashboard/login?redirect=" + path);
					}
				}
			} else {
				if (Request.IsAuthenticated) {
					Response.Redirect("/dashboard");
				}
			}
		}

		protected void Page_Load(object sender, EventArgs e) {
			// Check if user is logged in
			if (Request.IsAuthenticated) {
				HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
				// Check if user is an admin
				if (UserModel.isAdmin(authCookie)) {
					String list = "<li>"
								+ "<a href=\"#\"><i class=\"fa fa-users fa-fw\"></i> Admin<span class=\"fa arrow\"></span></a>"
								+	"<ul class=\"nav nav-second-level\">"
								+		"<li><a href=\"/dashboard/admin/users\">View all Users</a></li>"
								+		"<li><a href=\"/dashboard/admin/cars\">View all Cars</a></li>"
								+		"<li><a href=\"/dashboard/admin/issues\">View all Issues</a></li>"
								+		"<li><a href=\"/dashboard/admin/addcar\">Add new Car</a></li>"
								+		"<li><a href=\"/dashboard/admin/map\">View Car Map</a></li>"
								+	"</ul>"
								+ "</li>";
					adminList.Controls.Add(new LiteralControl(list));
				}
			}
		}
	}
}

/*


*/