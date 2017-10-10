using System;
using System.Collections.Generic;
using car_sharing_system.Models;
using System.Web.UI;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
			
			List<Booking> bookings = DatabaseReader.bookingQuery("accountID = '" + User.Identity.Name + "' ORDER BY startDate DESC ");
			if (bookings != null && bookings.Any()) {
				foreach (Booking book in bookings) {
					Car car = DatabaseReader.carQuerySingle("numberPlate = '" + book.numberPlate + "'");
					String bookrow;
					if (book.isFinish()) {
						if (!book.isOverdue()) {
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
        }
    }
}

/*
	<tr>
		<th>(ASDASD) Suzuki X</th>
		<th>ddddd, dd MMMM yyyy at hh:mm</th>
		<th>ddddd, dd MMMM yyyy at hh:mm</th>
		<th>$xx.xx</th>
	</tr>
*/
