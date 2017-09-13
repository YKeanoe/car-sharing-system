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


			HtmlGenericControl div1 = new HtmlGenericControl("div");
			div1.Attributes.Add("class", "feature-list");
			StringBuilder carPanelHTML = new StringBuilder();
			addHTML(carPanelHTML, currentCar.gps, "GPS");
			addHTML(carPanelHTML, currentCar.cdPlayer, "CD Player");
			addHTML(carPanelHTML, currentCar.bluetooth, "Bluetooth");
			addHTML(carPanelHTML, currentCar.cruiseControl, "Cruise Control");
			addHTML(carPanelHTML, currentCar.reverseCam, "Reverse Camera");
			addHTML(carPanelHTML, currentCar.radio, "Radio");
			div1.InnerHtml = carPanelHTML.ToString();
			//featurelist.Controls.Add(div1);
		}

		private void addHTML(StringBuilder panel, bool feat, String feature) {
			if (feat) {
				panel.AppendFormat("<i class=\"fa fa-check fa - fw\" ></i> " + feature);
			} else {
				panel.AppendFormat("<i class=\"fa fa-times fa - fw\" ></i> " + feature);
			}
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