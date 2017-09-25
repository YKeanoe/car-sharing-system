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
		
		String numberPlate;
		int startDate;
		int endDate;
		static Location latlong;



		protected void Page_Load(object sender, EventArgs e) {

			numberPlate = Request.QueryString["id"];
			startDate = Int32.Parse(Request.QueryString["sdate"]);
			endDate = Int32.Parse(Request.QueryString["edate"]);

			String query = "status = TRUE AND numberPlate = '" + numberPlate + "'";
			Debug.WriteLine(query);

			Car currentCar = DatabaseReader.carQuerySingleFull(query);
			//currentCar.fulldebug();
			// Uncomment to change database
			//DatabaseReader.checkCarStatus(currentCar.numberPlate);
			//DatabaseReader.disableCar(currentCar.numberPlate);
			//DatabaseReader.checkCarStatus(currentCar.numberPlate);

			carNumberPlate.Text = numberPlate;
			carLocation = currentCar.latlong;
			carBrandLabel.Text = currentCar.brand;
			carModelLabel.Text = currentCar.model;
			char transmission = currentCar.transmission;
			if (transmission.Equals('A')) {
				carTransmissionLabel.Text = "Automatic";
			} else {
				carTransmissionLabel.Text = "Manual";
			}
			int seats = currentCar.seats;
			carSeatsLabel.Text = seats + " Seats";
			carTypeLabel.Text = currentCar.vehicleType;
			Double rate = currentCar.rate;
			carRateLabel.Text = "$" + rate.ToString("00.00") + " per Hour";


			HtmlGenericControl div1 = new HtmlGenericControl("div");
			div1.Attributes.Add("class", "feature-list");
			StringBuilder carPanelHTML = new StringBuilder();
			carPanelHTML.Append("<div class=\"panel-half\"> ");
			addHTML(carPanelHTML, currentCar.gps, "GPS");
			addHTML(carPanelHTML, currentCar.cdPlayer, "CD Player");
			addHTML(carPanelHTML, currentCar.bluetooth, "Bluetooth");
			carPanelHTML.Append("</div>");
			carPanelHTML.Append("<div class=\"panel-half\"> ");
			addHTML(carPanelHTML, currentCar.cruiseControl, "Cruise Control");
			addHTML(carPanelHTML, currentCar.reverseCam, "Reverse Camera");
			addHTML(carPanelHTML, currentCar.radio, "Radio");
			carPanelHTML.Append("</div>");
			div1.InnerHtml = carPanelHTML.ToString();
			featurelist.Controls.Add(div1);
		}

		private void addHTML(StringBuilder panel, bool feat, String feature) {
			if (feat) {
				panel.AppendFormat("<i class=\"fa fa-check fa-fw\" ></i> " + feature);
			} else {
				panel.AppendFormat("<i class=\"fa fa-times fa-fw\" ></i> " + feature);
			}
			panel.Append("<br />");

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
		public static void cancelBooking(String id) {
			String query = "numberPlate = '" + id + "'";
			Car currentCar = DatabaseReader.carQuerySingleFull(query);
			DatabaseReader.enableCar(currentCar.numberPlate);
		}

		protected void confirmBook(object sender, EventArgs e) {
			
			Booking book = new Booking(Int32.Parse(User.Identity.Name), numberPlate, startDate, endDate, latlong);
			book.debug();
			
			//DatabaseReader.addBooking(book);
		}

		[System.Web.Services.WebMethod]
		public static void setLoc(String lat, String lng) {
			Location userLoc = new Models.Location(Convert.ToDecimal(lat), Convert.ToDecimal(lng));
			latlong = userLoc;
			//userLoc.debug();
		}

	}
}