using System;
using System.Collections.Generic;
using car_sharing_system.Models;
using System.Web.UI;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;

namespace car_sharing_system.Views
{
    public partial class bookingadmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
			// Admin permission check
			HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			if (!UserModel.isAdmin(authCookie)) {
				Response.Redirect("/dashboard/");
			}

			int uid;
			if (!string.IsNullOrEmpty(Request.QueryString["id"])) {
				uid = Convert.ToInt32(Request.QueryString["id"]);
				User currUser = DatabaseReader.userQuerySingle("accountID = '" + uid + "'");
				userlabel.Text = currUser.fname + " " + currUser.lname;
				List<Booking> bookings = DatabaseReader.bookingQuery("accountID = '" + uid + "' ORDER BY startDate DESC ");
				if (bookings != null && bookings.Any()) {
					foreach (Booking book in bookings) {
						Car car = DatabaseReader.carQuerySingle("numberPlate = '" + book.numberPlate + "'");
						String bookrow;
						if (book.isFinish()) {
							if (!book.isOverdue()) {
								if (book.totalCost >= 0) {
									bookrow = String.Format("<tr>"
													+ "<th>({0}) {1} {2}</th>"
													+ "<th>{3}</th>"
													+ "<th>{4}</th>"
													+ "<th class=\"align-right\">-</th>"
													+ "<th class=\"align-right\">${5}</th>"
													+ "</tr>", car.numberPlate, car.brand, car.model,
													new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.startDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
													new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.endDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
													book.totalCost);
								} else {
									bookrow = String.Format("<tr>"
													+ "<th>({0}) {1} {2}</th>"
													+ "<th>{3}</th>"
													+ "<th>{4}</th>"
													+ "<th class=\"align-right\">-</th>"
													+ "<th class=\"align-right\">Canceled</th>"
													+ "</tr>", car.numberPlate, car.brand, car.model,
													new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.startDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
													new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.endDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"));
								}
							} else {
								StringBuilder odString = new StringBuilder();
								TimeSpan od = book.overdueTime();
								if (od != null) {
									if (od.Days > 0) {
										odString.AppendFormat("{0} days, ", od.Days);
									}
									if (od.Hours > 0) {
										odString.AppendFormat("{0} hours ", od.Hours);
										if (od.Minutes > 0) {
											odString.Append("and ");
										}
									}
									if (od.Minutes > 0) {
										odString.AppendFormat("{0} minutes", od.Minutes);
									}
								}
								bookrow = String.Format("<tr class=\"table-warning\">"
									+ "<th>({0}) {1} {2}</th>"
									+ "<th>{3}</th>"
									+ "<th>{4}</th>"
									+ "<th class=\"align-right\">{5}</th>"
									+ "<th class=\"align-right\">${6}</th>"
									+ "</tr>", car.numberPlate, car.brand, car.model,
									new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.startDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
									new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.endDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
									odString.ToString(),
									book.totalCost);
							}

						} else {
							bookrow = String.Format("<tr class=\"table-success\">"
											+ "<th>({0}) {1} {2}</th>"
											+ "<th>{3}</th>"
											+ "<th>{4}</th>"
											+ "<th class=\"align-right\">-</th>"
											+ "<th class=\"align-right\">${5}</th>"
											+ "</tr>", car.numberPlate, car.brand, car.model,
											new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.startDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
											new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.estEndDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
											book.totalCost);
						}
						bookinglistph.Controls.Add(new LiteralControl(bookrow));
					}
				}
			} else {
				Response.Redirect("/dashboard/");
			}
		}
    }
}
