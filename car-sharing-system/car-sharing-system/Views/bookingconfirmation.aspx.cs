using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace car_sharing_system.Views.Admin_Theme.pages
{
	public partial class bookingconfirmation : System.Web.UI.Page
	{
		static Location carLocation;

		protected void Page_Load(object sender, EventArgs e)
		{
			String id = Request.QueryString["id"];

			String query = "numberPlate = '" + id + "'";
			Debug.WriteLine(query);

			Car currentCar = DatabaseReader.carQuerySingleFull(query);
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
			carRateLabel.Text = "$" + rate + " per Hour";


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
	}
}