using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace car_sharing_system.Views.Admin_Theme.pages {
	public partial class bookingcancel : System.Web.UI.Page {
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
			if (currBooking.startDate <= currentUnixTime) {
				carinfo.Style.Add("display", "none");
				returndiv.Style.Add("display", "block");
				errorlabel.Text = "Your booking is already running.";
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
				char transmission = currentCar.transmission;
				carTransmissionLabel.Text = (transmission.Equals('A')) ? "Automatic" : "Manual";
				carSeatsLabel.Text = currentCar.seats + " Seats";
				carTypeLabel.Text = currentCar.vehicleType;
				carRateLabel.Text = "$" + currentCar.rate.ToString("00.00") + " per Hour";

				bookStartTime.Text = "From " + new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(currBooking.startDate)).ToLocalTime().ToString("dddd, dd MMMMM yyyy HH:mm");
				bookEndTime.Text = "To " + new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(currBooking.estEndDate)).ToLocalTime().ToString("dddd, dd MMMMM yyyy HH:mm");

				Double estPrice = (Double)(currBooking.estEndDate - currBooking.startDate) / 3600 * currentCar.rate;
				bookEstimatePrice.Text = "$" + estPrice.ToString("00.00");

				featureHTML(leftfeat, currentCar.gps, "GPS");
				featureHTML(leftfeat, currentCar.cdPlayer, "CD Player");
				featureHTML(leftfeat, currentCar.bluetooth, "Bluetooth");

				featureHTML(rightfeat, currentCar.cruiseControl, "Cruise Control");
				featureHTML(rightfeat, currentCar.reverseCam, "Reverse Camera");
				featureHTML(rightfeat, currentCar.radio, "Radio");

				// Set global var
				HttpContext.Current.Session["carid"] = currentCar.numberPlate;
				HttpContext.Current.Session["carlocation"] = currentCar.latlong;

				script.Controls.Add(new LiteralControl("<script src=\"/Theme/js/idle-timer.min.js\"></script>"));
				script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/timeout-features-return.js\"></script>"));
			}
		}

		private void featureHTML(PlaceHolder ph, bool feat, String feature) {
			if (feat) {
				ph.Controls.Add(new LiteralControl("<i class=\"fa fa-check fa-fw\"></i> " + feature));
			} else {
				ph.Controls.Add(new LiteralControl("<i class=\"fa fa-times fa-fw\"></i> " + feature));
			}
			ph.Controls.Add(new LiteralControl("<br />"));
		}

		protected void cancelBook(object sender, EventArgs e) {
			String carid = (String)HttpContext.Current.Session["carid"];
			Location carloc = (Location)HttpContext.Current.Session["carlocation"];
			DatabaseReader.finishBooking(User.Identity.Name, 0, carid, carloc, -1);
			Response.Redirect("/dashboard/");
		}

		protected override void OnUnload(EventArgs e) {
			base.OnUnload(e);
			HttpContext.Current.Session.Remove("carid");
			HttpContext.Current.Session.Remove("carlocation");
		}
	}
}