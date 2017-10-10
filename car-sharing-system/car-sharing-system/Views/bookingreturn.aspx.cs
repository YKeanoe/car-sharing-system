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
	public partial class bookingreturn : System.Web.UI.Page {
		/*
		static Location userLocation;
		static Location carLocation;
		static String id;
		static String carid;
		*/

		protected void Page_Load(object sender, EventArgs e) {
			Booking currBooking = DatabaseReader.bookingQuerySingle("accountID = '" + User.Identity.Name + "' AND totalCost IS NULL;");
			if (currBooking == null) {
				carinfo.Style.Add("display", "none");
				errorinfo.Style.Add("display", "block");
				errorlabel.Text = "You don't have active booking.";
				return;
			}
			Car currentCar = DatabaseReader.carQuerySingleFull("numberPlate = '" + currBooking.numberPlate + "' AND Status != 'A'");
			if (currentCar == null) {
				carinfo.Style.Add("display", "none");
				errorinfo.Style.Add("display", "block");

				errorlabel.Text = "Sorry. We can't seem to find your booked car. Please try again from the dashboard.";
				return;
			}
			errorinfo.Style.Add("display", "none");
			carinfo.Style.Add("display", "block");

			// Set page's labels
			carNumberPlate.Text = currentCar.numberPlate;
			carBrandLabel.Text = currentCar.brand;
			carModelLabel.Text = currentCar.model;
			char transmission = currentCar.transmission;
			carTransmissionLabel.Text = (transmission.Equals('A')) ? "Automatic" : "Manual";
			carSeatsLabel.Text = currentCar.seats + " Seats";
			carTypeLabel.Text = currentCar.vehicleType;
			carRateLabel.Text = "$" + currentCar.rate.ToString("00.00") + " per Hour";

			DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(currBooking.startDate));
			bookStartTime.Text = "From " + startTime.ToLocalTime().ToString("dddd, dd MMMMM yyyy HH:mm");

			DateTime estEnd = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(currBooking.estEndDate));
			bookEndTime.Text = "To " + estEnd.ToLocalTime().ToString("dddd, dd MMMMM yyyy HH:mm");

			int overdue = DateTime.Compare(DateTime.UtcNow, estEnd);

			Double totalPrice;
			TimeSpan diff;
			if (overdue > 0) {
				diff = DateTime.UtcNow.Subtract(estEnd);
				StringBuilder odString = new StringBuilder();
				odString.Append("<label style=\"color:red;\"> Overdue for ");
				if (diff.Days > 0) {
					odString.AppendFormat("{0} days, ", diff.Days);
				}
				if (diff.Hours > 0) {
					odString.AppendFormat("{0} hours ", diff.Hours);
					if (diff.Minutes > 0) {
						odString.Append("and ");
					}
				}
				if (diff.Minutes > 0) {
					odString.AppendFormat("{0} minutes", diff.Minutes);
				}
				odString.Append("</label>");
				bookOverdue.Controls.Add(new LiteralControl(odString.ToString()));
			} else {
				diff = estEnd.Subtract(startTime);
			}

			totalPrice = Math.Ceiling(diff.TotalHours) * currentCar.rate;
			bookEstimatePrice.Text = "$" + totalPrice.ToString("00.00");

			HttpContext.Current.Session["carlocation"] = currentCar.latlong;
			HttpContext.Current.Session["carid"] = currentCar.numberPlate;
			HttpContext.Current.Session["totalcost"] = totalPrice;


			script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/booking-return-features.js\"></script>"));
			script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/timeout-features-return.js\"></script>"));
		}

		private void featureHTML(PlaceHolder ph, bool feat, String feature) {
			if (feat) {
				ph.Controls.Add(new LiteralControl("<i class=\"fa fa-check fa-fw\"></i> " + feature));
			} else {
				ph.Controls.Add(new LiteralControl("<i class=\"fa fa-times fa-fw\"></i> " + feature));
			}
			ph.Controls.Add(new LiteralControl("<br />"));
		}
	
		protected void confirmReturn(object sender, EventArgs e) {
			String carid = (String) HttpContext.Current.Session["carid"];
			Double totalPrice = (Double) HttpContext.Current.Session["totalCost"];
			Location uloc = (Location)HttpContext.Current.Session["userlocation"];
			Location cloc = (Location)HttpContext.Current.Session["carlocation"];
			var locA = new GeoCoordinate(Convert.ToDouble(cloc.lat), Convert.ToDouble(cloc.lng));
			var locB = new GeoCoordinate(Convert.ToDouble(uloc.lat), Convert.ToDouble(uloc.lng));
			double distance = locA.GetDistanceTo(locB); // metres

			DatabaseReader.finishBooking(User.Identity.Name, distance, carid, uloc, totalPrice);
			Response.Redirect("/dashboard/returnsuccess?lat=" + uloc.lat + "&lng=" + uloc.lng);
		}

		protected void confirmReturnAdmin(object sender, EventArgs e) {
			String carid = (String)HttpContext.Current.Session["carid"];
			Double totalPrice = (Double)HttpContext.Current.Session["totalCost"];
			Location uloc = (Location)HttpContext.Current.Session["userlocation"];
			Location cloc = (Location)HttpContext.Current.Session["carlocation"];

			Random rand = new Random();
			int y = rand.Next(-3, 2);
			Double x = rand.NextDouble();
			Double randlat = y + x;
			decimal lat = uloc.lat + Convert.ToDecimal(randlat);
			decimal lng = uloc.lng + Convert.ToDecimal(randlat);
			uloc.lat = lat;
			uloc.lng = lng;

			var locA = new GeoCoordinate(Convert.ToDouble(cloc.lat), Convert.ToDouble(cloc.lng));
			var locB = new GeoCoordinate(Convert.ToDouble(uloc.lat), Convert.ToDouble(uloc.lng));
			double distance = locA.GetDistanceTo(locB); // metres

			DatabaseReader.finishBooking(User.Identity.Name, distance, carid, uloc, totalPrice);
			Response.Redirect("/dashboard/returnsuccess?lat="+lat+"&lng="+lng);
		}

		protected override void OnUnload(EventArgs e) {
			base.OnUnload(e);
			HttpContext.Current.Session.Remove("carid");
			HttpContext.Current.Session.Remove("totalCost");
			HttpContext.Current.Session.Remove("userlocation");
			HttpContext.Current.Session.Remove("carlocation");
		}

		[System.Web.Services.WebMethod]
		public static void setLoc(String lat, String lng) {
			//userLocation = new Models.Location(Convert.ToDecimal(lat), Convert.ToDecimal(lng));
			HttpContext.Current.Session["userlocation"] = new Location(Convert.ToDecimal(lat), Convert.ToDecimal(lng));
			//userLoc.debug();
		}
	}
}