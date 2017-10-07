using System;
using System.Collections.Generic;
using car_sharing_system.Models;
using System.Web.UI;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
			
			List<Booking> bookings = DatabaseReader.bookingQuery("accountID = '" + User.Identity.Name + "'");
			if (bookings == null) {
				foreach (Booking book in bookings) {
					Car car = DatabaseReader.carQuerySingle("numberPlate = '" + book.numberPlate + "'");
					String bookrow;
					if (book.isFinish()) {
						bookrow = String.Format("<tr>"
										+ "<th>({0}) {1} {2}</th>"
										+ "<th>{3}</th>"
										+ "<th>{4}</th>"
										+ "<th>${5}</th>"
										+ "</tr>", car.numberPlate, car.brand, car.model,
										new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.startDate)).ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
										new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.endDate)).ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
										book.calCost());
					} else {
						bookrow = String.Format("<tr>"
										+ "<th>({0}) {1} {2}</th>"
										+ "<th>{3}</th>"
										+ "<th>{4}</th>"
										+ "<th>${5}</th>"
										+ "</tr>", car.numberPlate, car.brand, car.model,
										new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.startDate)).ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
										new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.endDate)).ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
										book.calCost());
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
