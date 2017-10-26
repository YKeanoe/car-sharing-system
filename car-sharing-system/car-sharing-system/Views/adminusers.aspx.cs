using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Text;
using System.Diagnostics;

namespace car_sharing_system.Admin_Theme.pages {
	public partial class adminusers : System.Web.UI.Page {
		protected String fill;

		protected void Page_Load(object sender, EventArgs e) {
			// Admin permission check
			HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			if (!UserModel.isAdmin(authCookie)) {
				Response.Redirect("/dashboard/");
			}

			int page;
			if (!string.IsNullOrEmpty(Request.QueryString["page"])) {
				page = Convert.ToInt32(Request.QueryString["page"]);
			} else {
				page = 1;
			}

			double pagersCount = (double)DatabaseReader.UserCount(null) / 100;

			Debug.WriteLine((int)Math.Ceiling(pagersCount));

			setpages((int) Math.Ceiling(pagersCount), page);
			
			/*
			for (int i = 0; i < pagersCount; i++) {
				int j = i + 1;
				pagers.InnerHtml = pagers.InnerHtml +
					"<a href='?page=" + j + "'>" + j + "</a> ";
			}
			*/

			postUsers(page * 100);
		}

		private void setpages(int page, int currpage) {
			StringBuilder pagesb = new StringBuilder();
			for (int i = 1; i <= page; i++) {
				if (i == currpage) {
					pagesb.Append("<li class=\"active\"><a href=\"?page=" + i + "\"> " + i + "</a></li>");
				} else {
					pagesb.Append("<li><a href=\"?page=" + i + "\"> " + i + "</a></li>");
				}
			}
			pages.Controls.Add(new LiteralControl(pagesb.ToString()));
		}

		protected void postUsers(int i) {
			Debug.WriteLine("post users i = " + i);
			if (i != 0)
				i = i - 100;

			Debug.WriteLine("post users i = " + i);
			List<User> users = DatabaseReader.userQuery(" 1 = 1 LIMIT 100 OFFSET " + i);

			if (users == null) {
				Response.Redirect("~/Views/adminusers.aspx");
			}

			StringBuilder usertable = new StringBuilder();
			foreach (User curr in users) {
				usertable.Append(theRows(curr));
				//Usertable.InnerHtml = Usertable.InnerHtml + theRows(curr);
			}
			userrow.Controls.Add(new LiteralControl(usertable.ToString()));
		}

		protected String theRows(User curr) {

			return String.Format("<tr>"
									+ "<td>{0}</td>"
									+ "<td>{1} {2}</td>"
									+ "<td>{3}</td>"
									+ "<td>{4}</td>"
									+ "<td><a class=\"btn btn-primary btn-table\" href=\"/dashboard/profile?edit={0}/\" role=\"button\">Profile</a></td>"
									+ "<td><a class=\"btn btn-primary btn-table\" href=\"/dashboard/admin/userbooking?id={0}\" role=\"button\">Booking History</a></td>"
									+ "</tr>", curr.id, curr.fname, curr.lname, curr.licenseNo.ToString(), curr.email);
			
			/*
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
			*/
		}
	}
}