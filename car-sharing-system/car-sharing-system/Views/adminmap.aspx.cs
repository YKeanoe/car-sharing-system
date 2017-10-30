using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Text;
using System.Diagnostics;

namespace car_sharing_system.Views {
	public class GoogleCarLocation {
		public String carName { get; set; }
		public Location loc { get; set; }
		public GoogleCarLocation(String n, Location l) {
			carName = n;
			loc = l;
		}
	}

	public partial class adminmap : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			// Admin permission check
			HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			if (!UserModel.isAdmin(authCookie)) {
				Response.Redirect("/dashboard/");
			}
		}

		[System.Web.Services.WebMethod]
		public static string getCarsData() {
			// Dummy data. Change query to "status = 'U'" when done
			Random rand = new Random();
			int i = rand.Next(0,15);
			int off = 500 * i;
			List<Car> cars = DatabaseReader.carQuery("status = 'A' LIMIT 5 OFFSET " + off);
			return generateGoogleCarLocation(cars);
		}

		private static String generateGoogleCarLocation(List<Car> cars) {
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			List<GoogleCarLocation> carlocs = new List<GoogleCarLocation>();
			foreach (Car car in cars) {
				carlocs.Add(new GoogleCarLocation(car.getCarAsTitle(), car.latlong));
			}
			return oSerializer.Serialize(carlocs);
		}
	}
}