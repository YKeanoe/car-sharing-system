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

			//DatabaseReader.carQuery("status = FALSE");
            //getCarsData("jimmy", "jommy");
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
												bool revcam ) {

			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			List<GoogleCarLocation> carlocs = new List<GoogleCarLocation>();

			Random rand = new Random();
			CarModel cm = CarModel.getInstance();
			List<Car> closeCars = cm.getCloseCarFiltered(Double.Parse(lat), Double.Parse(lng),
														sdate, edate, // Starting and ending date
														brand,
														seat,
														sortby,
														transmission,
														type,
														adv, cd, bt, gps, cc, rad, revcam );

			if (closeCars == null) {
				return null;
			}

			foreach (Car car in closeCars) {
				carlocs.Add(new GoogleCarLocation(car.getCarAsTitle(), car.latlong, rand.Next(1, 50)));
			}

			return oSerializer.Serialize(carlocs);
		}

		[System.Web.Services.WebMethod]
		public static string getCarPage(int page) {
			Debug.WriteLine("text rec = " + page);
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			List<GoogleCarLocation> carlocs = new List<GoogleCarLocation>();

			Random rand = new Random();
			CarModel cm = CarModel.getInstance();

			List<Car> randCars = cm.getRandomCars();
			//List<Car> closeCars = cm.getCloseCar(Double.Parse(lat), Double.Parse(lng));


			foreach (Car car in randCars) {
				carlocs.Add(new GoogleCarLocation(car.getCarAsTitle(), car.latlong, rand.Next(1, 50)));
			}

			return oSerializer.Serialize(carlocs);
		}
		[System.Web.Services.WebMethod]
		public static string getCarsData(String lat, String lng) {
			//Debug.WriteLine("text rec = " + lat + ", " + lng);
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			List<GoogleCarLocation> carlocs = new List<GoogleCarLocation>();

			Random rand = new Random();
			CarModel cm = CarModel.getInstance();
			//List<Car> randCars = cm.getRandomCars();
			List<Car> closeCars = cm.getCloseCar(Double.Parse(lat), Double.Parse(lng));
			

			foreach (Car car in closeCars) {
				carlocs.Add(new GoogleCarLocation(car.getCarAsTitle(), car.latlong, rand.Next(1,50)));
			}

			return oSerializer.Serialize(carlocs);
		}
  }
}