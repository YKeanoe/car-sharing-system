using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Text;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Web.Script.Services;

namespace car_sharing_system {
	public class GoogleCarLocation {
		public String carName { get; set; }
		public Location loc { get; set; }
		public int dist { get; set; }
		public GoogleCarLocation(String n, Location l, int d) {
			carName = n;
			loc = l;
			dist = d;
		}
	}

	public partial class FrontPage : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

			DatabaseReader.carQuery("status = FALSE");
            getCarsData();
        }

		[System.Web.Services.WebMethod]
		public static string getCarsData() {
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			List<GoogleCarLocation> carlocs = new List<GoogleCarLocation>();

			CarModel cm = CarModel.getInstance();
			//List<Car> randCars = cm.getRandomCars();
            List<Car> closeCars = new Search().find(-37.813628, 144.9651170);
            Random rand = new Random();

			foreach (Car car in closeCars) {
				carlocs.Add(new GoogleCarLocation(car.getCarAsTitle(), car.latlong, rand.Next(1,50)));
			}

			return oSerializer.Serialize(carlocs);
		}
  }
}