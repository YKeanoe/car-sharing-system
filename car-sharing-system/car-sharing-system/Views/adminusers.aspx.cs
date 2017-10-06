using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;

namespace car_sharing_system.Admin_Theme.pages {
	public partial class adminusers : System.Web.UI.Page {
		protected user admin;
		protected List<user> users = new List<user>();
		protected String fill;

		protected void Page_Load(object sender, EventArgs e) {
			int page = 0;


			admin = DatabaseReader.userQuerySingle("accountID = '" + User.Identity.Name + "';");

			if (admin == null || admin.permission == 0) {
				Response.Redirect("/dashboard/");
			}
			if (!string.IsNullOrEmpty(Request.QueryString["page"])) {
				page = Convert.ToInt32(Request.QueryString["page"]);
			}
			double pagersCount = (double)DatabaseReader.UserCount(null) / 100;

			for (int i = 0; i < pagersCount; i++) {
				int j = i + 1;
				pagers.InnerHtml = pagers.InnerHtml +
					"<a href='?page=" + j + "'>" + j + "</a> ";
			}
			postUsers(page * 100);
		}
		protected void postUsers(int i) {
			if (i != 0)
				i = i - 100;
			users = DatabaseReader.userQuery(" 1 = 1 LIMIT 100 OFFSET " + i);
			if (users == null) {
				Response.Redirect("~/Views/adminusers.aspx");
			}
			foreach (user curr in users) {
				Usertable.InnerHtml = Usertable.InnerHtml + theRows(curr);


			}
		}
		protected String theRows(user curr) {

			return "<div class='userrow'>\n" +
						"<div class='cell firstCol'>\n" +
							"<span>" + curr.id.ToString() + "</span>\n" +
						"</div>\n" +
						"<div class='cell col'>\n" +
							"<span>" + curr.fname + " " + curr.lname + "</span>\n" +
						"</div>\n" +
						"<div class='cell col lic'>\n" +
							"<span>" + curr.licenseNo.ToString() + "</span>\n" +
						"</div>\n" +
						"<div class='cell col em'>\n" +
							"<span>" + curr.email + "</span>\n" +
						"</div>\n" +
						"<div class='cell col'>\n" +
							"<a type='button' href='/dashboard/profile?edit=" + curr.id.ToString() +
							"'>View User's Profile</a>\n" +
						"</div>\n" +
						"<div class='cell col'>\n" +
							"<a type='button' href='adminviewbookinghistory&id=" + curr.id.ToString() +
							"'>View User's Booking History</a>\n" +
						"</div>\n" +
					"</div>\n";
		}
	}
}