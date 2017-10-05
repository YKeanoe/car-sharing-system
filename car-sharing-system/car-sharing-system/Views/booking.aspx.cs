using System;
using System.Collections.Generic;
using car_sharing_system.Models;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {

			List<Booking> bookings = DatabaseReader.bookingQuery("accountID = '" + User.Identity.Name + "'");
			if (bookings == null) {

			}
        }
    }
}