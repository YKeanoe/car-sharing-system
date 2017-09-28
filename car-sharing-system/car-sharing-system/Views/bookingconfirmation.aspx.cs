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
		int startDate;
		int endDate;
		static Location userLocation;

		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				String tid, tsd, ted;
				tid = Request.QueryString["id"];
				tsd = Request.QueryString["sdate"];
				ted = Request.QueryString["edate"];
				if (!String.IsNullOrEmpty(tid) && !String.IsNullOrEmpty(tsd) && !String.IsNullOrEmpty(ted)) {
					numberPlate = Request.QueryString["id"];
					startDate = Int32.Parse(Request.QueryString["sdate"]);
					endDate = Int32.Parse(Request.QueryString["edate"]);
				} else {
					Response.Redirect("/");
				}
				String query = "status = 'A' AND numberPlate = '" + numberPlate + "'";

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
				} else {
					Response.Redirect("/");
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
			DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			long currentunix = (long)DateTime.Now.Subtract(unixStart).TotalSeconds;

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