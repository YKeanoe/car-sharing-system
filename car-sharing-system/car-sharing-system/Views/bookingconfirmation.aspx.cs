using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using car_sharing_system.Models;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Text;
using System.Device.Location;

namespace car_sharing_system.Views.Admin_Theme.pages {
	public partial class bookingconfirmation : System.Web.UI.Page {

		static Location carLocation;
		
		static String numberPlate;
		long startDate;
		long endDate;
		static Location userLocation;

		protected void Page_Load(object sender, EventArgs e) {

			// Check if its a postback
			if (!IsPostBack) {
				// If it is not a postback, fill the page
				// Check if user have a booking
				Booking currBooking = DatabaseReader.bookingQuerySingle("accountID = '" + User.Identity.Name + "' AND endDate IS NULL;");
				if (currBooking != null) {
					carinfo.Style.Add("display", "none");
					returndiv.Style.Add("display", "block");
					errorlabel.Text = "You cannot book multiple car at the same time.";
					script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/booking-confirmation-error.js\"></script>"));
					return;
				}
				
				returndiv.Style.Add("display", "none");
				carinfo.Style.Add("display", "block");

				String tid, tsd, ted;
				tid = Request.QueryString["id"];
				tsd = Request.QueryString["sdate"];
				ted = Request.QueryString["edate"];
				if (!String.IsNullOrEmpty(tid) && !String.IsNullOrEmpty(tsd) && !String.IsNullOrEmpty(ted)) {
					numberPlate = Request.QueryString["id"];
					startDate = Convert.ToInt64(Request.QueryString["sdate"]);
					endDate = Convert.ToInt64(Request.QueryString["edate"]);
				} else {
					carinfo.Style.Add("display", "none");
					returndiv.Style.Add("display", "block");
					script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/booking-confirmation-error.js\"></script>"));
					errorlabel.Text = "Sorry. There seems to be something wrong with the link. Please try to book again from the dashboard.";
					return;
				}
				String query = "status = 'A' AND numberPlate = '" + numberPlate + "'";
				Debug.WriteLine(startDate);
				Debug.WriteLine(endDate);
				Car currentCar = DatabaseReader.carQuerySingleFull(query);

				if (currentCar != null) {
					// Set the car status to be booked
					DatabaseReader.setCarBooked(currentCar.numberPlate);

					// Set page's labels
					carNumberPlate.Text = numberPlate;
					carLocation = currentCar.latlong;
					carBrandLabel.Text = currentCar.brand;
					carModelLabel.Text = currentCar.model;
					char transmission = currentCar.transmission;
					carTransmissionLabel.Text = (transmission.Equals('A')) ? "Automatic" : "Manual";
					carSeatsLabel.Text = currentCar.seats + " Seats";
					carTypeLabel.Text = currentCar.vehicleType;
					carRateLabel.Text = "$" + currentCar.rate.ToString("00.00") + " per Hour";

					bookStartTime.Text = "From " + new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(startDate)).ToLocalTime().ToString("dddd, dd MMMMM yyyy HH:mm");
					bookEndTime.Text = "To " + new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(endDate)).ToLocalTime().ToString("dddd, dd MMMMM yyyy HH:mm");

					Double estPrice = (Double)(endDate - startDate) / 3600 * currentCar.rate;
					bookEstimatePrice.Text = "$" + estPrice.ToString("00.00");

					featureHTML(leftfeat, currentCar.gps, "GPS");
					featureHTML(leftfeat, currentCar.cdPlayer, "CD Player");
					featureHTML(leftfeat, currentCar.bluetooth, "Bluetooth");

					featureHTML(rightfeat, currentCar.cruiseControl, "Cruise Control");
					featureHTML(rightfeat, currentCar.reverseCam, "Reverse Camera");
					featureHTML(rightfeat, currentCar.radio, "Radio");

					script.Controls.Add(new LiteralControl("<script src=\"/Theme/js/idle-timer.min.js\"></script>"));
					script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/booking-confirmation-map.js\"></script>"));
					script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/timeout-features.js\"></script>"));
					script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/booking-confirmation-features.js\"></script>"));
				} else {
					carinfo.Style.Add("display", "none");
					returndiv.Style.Add("display", "block");
					errorlabel.Text = "Sorry. We can't seem to find your choice of car. Please try again from the dashboard.";
					script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/booking-confirmation-error.js\"></script>"));
					return;
				}
				
			} else {
				// if it's a postback, fill the required data and not the page.
				String tid, tsd, ted;
				tid = Request.QueryString["id"];
				tsd = Request.QueryString["sdate"];
				ted = Request.QueryString["edate"];
				if (!String.IsNullOrEmpty(tid) && !String.IsNullOrEmpty(tsd) && !String.IsNullOrEmpty(ted)) {
					numberPlate = Request.QueryString["id"];
					startDate = Int32.Parse(Request.QueryString["sdate"]);
					endDate = Int32.Parse(Request.QueryString["edate"]);
				}
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

		private void disablePage() {
			carinfo.Style.Add("display", "none");
			returndiv.Style.Add("display", "block");

		}

		[System.Web.Services.WebMethod]
		public static String getCarLocation() {
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();

			if (carLocation != null) {
				return oSerializer.Serialize(carLocation);
			} else {
				return null;
			}
		}

		[System.Web.Services.WebMethod]
		public static void cancelBooking() {
			// Debug.WriteLine("booking canceled");			
			String query = "numberPlate = '" + numberPlate + "'";
			Car currentCar = DatabaseReader.carQuerySingleFull(query);
			DatabaseReader.enableCar(currentCar.numberPlate);	
		}

		protected void confirmBook(object sender, EventArgs e) {
			// Debug.WriteLine("Booking confirmed");
			Debug.WriteLine(startDate);
			Debug.WriteLine(endDate);

			DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			long currentunix = (long)DateTime.UtcNow.Subtract(unixStart).TotalSeconds;

			if (startDate < currentunix) {
				startDate = currentunix;
			}

			Booking book = new Booking(Int32.Parse(User.Identity.Name), numberPlate, currentunix, startDate, endDate, userLocation);
			// book.debug();
			DatabaseReader.addBooking(book);
			Response.Redirect("/dashboard/");
		}

		[System.Web.Services.WebMethod]
		public static void setLoc(String lat, String lng) {
			userLocation = new Models.Location(Convert.ToDecimal(lat), Convert.ToDecimal(lng));
		}
	}
}