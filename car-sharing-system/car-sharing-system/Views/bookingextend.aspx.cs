using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace car_sharing_system.Views.Admin_Theme.pages {
	public partial class bookingextend : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			// If it is not a postback, fill the page
			Booking currBooking = DatabaseReader.bookingQuerySingle("accountID = '" + User.Identity.Name + "' AND totalCost IS NULL;");
			// Check booking
			if (currBooking == null) {
				carinfo.Style.Add("display", "none");
				returndiv.Style.Add("display", "block");
				errorlabel.Text = "You do not have a running booking.";
				return;
			}

			// Check booking time
			long currentUnixTime = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			if (currBooking.estEndDate <= currentUnixTime) {
				carinfo.Style.Add("display", "none");
				returndiv.Style.Add("display", "block");
				errorlabel.Text = "Your booking is already overdue.";
				return;
			}

			returndiv.Style.Add("display", "none");
			carinfo.Style.Add("display", "block");

			String query = "status != 'A' AND numberPlate = '" + currBooking.numberPlate + "'";
			Car currentCar = DatabaseReader.carQuerySingleFull(query);
			if (currentCar != null) {
				// Set page's labels
				carNumberPlate.Text = currBooking.numberPlate;
				carBrandLabel.Text = currentCar.brand;
				carModelLabel.Text = currentCar.model;
				carRateLabel.Text = "$" + currentCar.rate.ToString("00.00") + " per Hour";

				bookStartTime.Text = "From " + new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(currBooking.startDate)).ToLocalTime().ToString("dddd, dd MMMMM yyyy HH:mm");
				bookEndTime.Text = "To " + new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(currBooking.estEndDate)).ToLocalTime().ToString("dddd, dd MMMMM yyyy HH:mm");

				Double estPrice = (Double)(currBooking.estEndDate - currBooking.startDate) / 3600 * currentCar.rate;
				bookEstimatePrice.Text = "$" + estPrice.ToString("00.00");

				HttpContext.Current.Session["startTime"] = currBooking.startDate;
				HttpContext.Current.Session["carRate"] = currentCar.rate;

				script.Controls.Add(new LiteralControl("<script src=\"/Theme/js/idle-timer.min.js\"></script>"));
				script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/timeout-features-return.js\"></script>"));
				script.Controls.Add(new LiteralControl("<script src=\"/Datetimepicker/js/bootstrap-datetimepicker.min.js\"></script>"));
				script.Controls.Add(new LiteralControl("<script src=\"/Theme/js/extend-feature.js\"></script>"));
			}
		}

		[System.Web.Services.WebMethod]
		public static string calCost(int newEndDate) {
			// Save the new end date to session
			HttpContext.Current.Session["newEndDate"] = newEndDate;
			long startDate = (long)HttpContext.Current.Session["startTime"];
			Double rate = (Double)HttpContext.Current.Session["carRate"];
			Double estPrice = (Double)(newEndDate - startDate) / 3600 * rate;
			// Return estimated cost
			return estPrice.ToString("00.00");
		}

		protected override void OnUnload(EventArgs e) {
			base.OnUnload(e);
			if (IsPostBack) {
				HttpContext.Current.Session.Remove("startTime");
				HttpContext.Current.Session.Remove("carRate");
			}
		}

		protected void extendBook(object sender, EventArgs e) {
			// Check if new end date exists
			if (HttpContext.Current.Session["newEndDate"] != null) {
				int eDate = (int)HttpContext.Current.Session["newEndDate"];
				long newEndDate = Convert.ToInt64(eDate);
				DatabaseReader.extendBooking(newEndDate, User.Identity.Name);
				Response.Redirect("/dashboard/");
			} else {
				errormsg.InnerText = "Please enter the new return date";
			}

		}
	}
}