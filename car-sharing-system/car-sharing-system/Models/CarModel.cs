using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Diagnostics;
using System.Device.Location;

namespace car_sharing_system.Models {
	public class CarModel {
		public List<Car> cars;

		public static CarModel getInstance() {
			if (HttpContext.Current.Session["CarModel"] == null) {
				HttpContext.Current.Session["CarModel"] = new CarModel();
			}
			return (CarModel)HttpContext.Current.Session["CarModel"];	
		}

		// Constructor
		private CarModel() {
		}

		public void refreshCars() {
			cars = DatabaseReader.carQuery(null);
			if (cars == null) {
				generateDummy(cars);
			}
		}

		// Grab random cars just for tests
		public List<Car> getRandomCars() {
			// Grab random car from cars data
			List<Car> randCars = new List<Car>();
			Random rand = new Random();
			int ran1 = rand.Next(1, 10);
			int ran2 = rand.Next(11, 20);
			int ran3 = rand.Next(21, 30);
			int ran4 = rand.Next(31, 40);
			int ran5 = rand.Next(51, 60);

			int[] randomInt = { ran1, ran2, ran3, ran4, ran5 };

			foreach (int i in randomInt) {
				randCars.Add(cars[i]);
			}
			return randCars;
		}

		// Create dummy data in case database isn't working
		public void generateDummy(List<Car> cars) {
			Location latlong1 = new Location(-37.816261m, 144.970976m);
			Location latlong2 = new Location(-37.815555m, 144.970107m);
			Location latlong3 = new Location(-37.815539m, 144.966278m);
			cars.Add(new Car("V123", latlong1, "Mercedes", "C Series", 5.00));
			cars.Add(new Car("V124", latlong2, "Mercedes", "A Series", 6.00));
			cars.Add(new Car("V125", latlong3, "Mercedes", "S Series", 6.30));
		}

		public List<Car> getCloseCar(Double lat, Double lng) {
			List<Car> dbcars = DatabaseReader.carQuery("Status = 'A'");
			cars = new Search(dbcars).find(lat,lng, 50);
			sortCarList(lat,lng,0);
			return cars.GetRange(0,5);
		}

		public static List<Car> getCloseCarAPI(Double lat, Double lng, int amt) {
			List<Car> dbcars = DatabaseReader.carQuery("Status = 'A'");
			List<Car> fcars = new List<Car>();
			fcars = new Search(dbcars).find(lat, lng, amt);
			Debug.WriteLine("fuuuuuuuck");
			sortCarListAPI(fcars, lat, lng, 0);
			return fcars;
		}

		public List<Car> getAllCar() {
			cars = DatabaseReader.carQueryAdmin(null);
			return cars.GetRange(0, 50);
		}

		public int countPages(int dataperpage) {
			return cars.Count / dataperpage;
		}

		public List<Car> getPageAllCar(int page) {
			int fpage = (page * 50) - 50;
			return cars.GetRange(fpage, 50);
		}

		// sortCarList function is used to sort the list of cars depending on
		// user to car range. It take user's lat and long as parameter and an
		// Integer to represent sortby's type. 0 represent range ASC, 1 
		// represent range DESC, 2 represent rate ASC, 3 represent rate DESC.
		public void sortCarList(Double lat, Double lng, int sortby) {
			foreach (Car car in cars) {
				var locA = new GeoCoordinate(lat, lng);
				var locB = new GeoCoordinate(Convert.ToDouble(car.latlong.lat), Convert.ToDouble(car.latlong.lng));
				double distance = locA.GetDistanceTo(locB); // metres
				car.rangeToUser = distance;
			}
			if (sortby == 0) {
				cars = cars.OrderBy(x => x.rangeToUser).ToList<Car>();
			} else if (sortby == 1) {
				cars = cars.OrderByDescending(x => x.rangeToUser).ToList<Car>();
			} else if (sortby == 1) {
				cars = cars.OrderBy(x => x.rate).ToList<Car>();
			} else {
				cars = cars.OrderByDescending(x => x.rate).ToList<Car>();
			}
		}

		public static List<Car> sortCarListAPI(List<Car> cars, Double lat, Double lng, int sortby) {
			foreach (Car car in cars) {
				var locA = new GeoCoordinate(lat, lng);
				var locB = new GeoCoordinate(Convert.ToDouble(car.latlong.lat), Convert.ToDouble(car.latlong.lng));
				double distance = locA.GetDistanceTo(locB); // metres
				car.rangeToUser = distance;
			}
			if (sortby == 0) {
				cars = cars.OrderBy(x => x.rangeToUser).ToList<Car>();
			} else if (sortby == 1) {
				cars = cars.OrderByDescending(x => x.rangeToUser).ToList<Car>();
			} else if (sortby == 1) {
				cars = cars.OrderBy(x => x.rate).ToList<Car>();
			} else {
				cars = cars.OrderByDescending(x => x.rate).ToList<Car>();
			}
			return cars;
		}

		public List<Car> getPageCar(int page) {
			int fpage = (page * 5) - 5;
			return cars.GetRange(fpage, 5);
		}

		public List<Car> getCloseCarFiltered(Double lat, Double lng,
											int sdate, int edate,
											String brand,
											String seat,
											int sortby,
											String transmission,
											String type,
											bool adv, bool cd,
											bool bt, bool gps,
											bool c, bool rad,
											bool revcam ) {
			StringBuilder query = new StringBuilder();
			if (!brand.Equals("Any")) {
				query.AppendFormat("brand = '{0}' " , brand);
			}

			if (!seat.Equals("Any")) {
				if (query.Length > 0) {
					query.Append("AND ");
				}
				query.AppendFormat("seats = {0} ", seat);
			}

			if (!type.Equals("Any")) {
				if (query.Length > 0) {
					query.Append("AND ");
				}
				query.AppendFormat("vehicleType = '{0}' ", type);
			}

			if (!transmission.Equals("Any")) {
				if (query.Length > 0) {
					query.Append("AND ");
				}
				query.AppendFormat("transmission = '{0}' ", transmission);
			}

			if (query.Length > 0) {
				query.Append("AND Status = 'A'");
			}

			List<Car> dbcars = DatabaseReader.carQuery(query.ToString());
			if (dbcars != null) {
				cars = new Search(dbcars).find(lat, lng, 50);
				sortCarList(lat, lng, sortby);
				return cars.GetRange(0,5);
			} else {
				return null;
			}
		}
	}
}