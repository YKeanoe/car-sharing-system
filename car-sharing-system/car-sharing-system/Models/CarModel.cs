using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models {
	public class CarModel {
		private static CarModel carModel;
		public List<Car> cars;
		public static CarModel getInstance() {
			if (carModel == null) {
				carModel = new Models.CarModel();
			}
			return carModel;
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
	}
}