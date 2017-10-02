using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Text;

namespace car_sharing_system.Admin_Theme.pages {
	public class GoogleCarLocation {
		public String carName { get; set; }
		public Location loc { get; set; }
		public Double dist { get; set; }
		public GoogleCarLocation(String n, Location l, Double d) {
			carName = n;
			loc = l;
			dist = d;
		}
	}

	public partial class dashboard : System.Web.UI.Page {
        protected User newUser;


        protected void Page_Load(object sender, EventArgs e) {
            newUser = DatabaseReader.userQuerySingle("accountID = '" + User.Identity.Name + "';");
			Booking currBooking = DatabaseReader.bookingQuerySingle("accountID = '" + User.Identity.Name + "' AND endDate IS NULL;");
			if (currBooking != null) {
				// If user have a running booking, then show the booking list
				cardiv.Style.Add("display", "none");
				booklistdiv.Style.Add("display", "block");

				Car currentCar = DatabaseReader.carQuerySingle("numberPlate = '" + currBooking.numberPlate + "'");
				carNumberPlate.Text = "(" + currentCar.numberPlate + ")";
				carBrandLabel.Text = currentCar.brand;
				carModelLabel.Text = currentCar.model;
				bookStart.Text = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(currBooking.startDate)).ToLocalTime().ToString("'Start on' dddd, dd MMMM yyyy 'at' HH:mm");

				DateTime estEnd = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(currBooking.estEndDate));
				bookEstEnd.Text = estEnd.ToLocalTime().ToString("'Booked until' dddd, dd MMMM yyyy 'at' HH:mm");
				
				int overdue = DateTime.Compare(DateTime.UtcNow, estEnd);
				if (overdue > 0) {
					TimeSpan diff = DateTime.UtcNow.Subtract(estEnd);
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
				}
			} else {
				// If user don't have a running booking, then show the car list
				cardiv.Style.Add("display", "block");
				booklistdiv.Style.Add("display", "none");
				script.Controls.Add(new LiteralControl("<script async defer src=\"https://maps.googleapis.com/maps/api/js?key=AIzaSyCVtkFkAt7qjm3egiu1VL8sHI-IJKtE5x8&libraries=geometry\"></script>"));
				script.Controls.Add(new LiteralControl("<script src=\"/Datetimepicker/js/bootstrap-datetimepicker.min.js\"></script>"));
				script.Controls.Add(new LiteralControl("<script src=\"/Theme/js/map-features.js\"></script>"));
				script.Controls.Add(new LiteralControl("<script src=\"/Theme/js/dropdown.js\"></script>"));
			}
		}

		[System.Web.Services.WebMethod]
		public static string getCarsDataFiltered(String lat, String lng,
												int sdate, int edate,
												String brand,
												String seat,
												int sortby,
												String transmission,
												String type,
												bool adv, bool cd,
												bool bt, bool gps,
												bool cc, bool rad,
												bool revcam) {
			CarModel cm = CarModel.getInstance();
			List<Car> closeCars = cm.getCloseCarFiltered(
												Double.Parse(lat), Double.Parse(lng),
												sdate, edate, // Start and end date
												brand,
												seat,
												sortby,
												transmission,
												type,
												adv, cd, bt, gps, cc, rad, revcam);
			if (closeCars == null) {
				return null;
			} else {
				return generateGoogleCarLocation(closeCars);
			}
		}

		[System.Web.Services.WebMethod]
		public static string getCarPage(int page) {
			CarModel cm = CarModel.getInstance();
			List<Car> closeCars = cm.getPageCar(page);
			return generateGoogleCarLocation(closeCars);
		}

		[System.Web.Services.WebMethod]
		public static string getCarsData(String lat, String lng) {
			CarModel cm = CarModel.getInstance();
			List<Car> closeCars = cm.getCloseCar(Double.Parse(lat), Double.Parse(lng));
			return generateGoogleCarLocation(closeCars);
		}

		private static String generateGoogleCarLocation(List<Car> cars) {
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			List<GoogleCarLocation> carlocs = new List<GoogleCarLocation>();

			foreach (Car car in cars) {
				carlocs.Add(new GoogleCarLocation(car.getCarAsTitle(), car.latlong,
												Math.Round(car.rangeToUser, 2)));
			}

			return oSerializer.Serialize(carlocs);
		}
	}
}
