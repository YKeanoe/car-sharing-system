using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using car_sharing_system.Models;
using System.Diagnostics;


namespace car_sharing_system.Controllers {
	public class CarController : System.Web.Http.ApiController {
		// GET api/car
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/car/{amount}
		// Use amount as to the amount of cars requested
		// Return available cars number plate
		[Route("api/car/{amount}")]
		public string Get(int amount) {
			//List<String> numberplates = new List<String>(new String[] { "AA11", "BB22", "CC33", "DD44" });
			//List<String> aCars = DatabaseReader.getAvailableCarPlates(amount);
			//return new JavaScriptSerializer().Serialize(aCars);
			List<Car> closeCars = CarModel.getCloseCarAPI(-37.813600, 144.963100, amount);
			List<String> aCars = new List<String>();
			foreach (Car car in closeCars) {
				aCars.Add(car.numberPlate);
				car.debug();
			}
			foreach (String car in aCars) {
				Debug.WriteLine(car);
			}

			return new JavaScriptSerializer().Serialize(aCars);

		}

		// GET api/car/id/{carID}
		// Use car number plate to find the car and return the car's current location.
		[HttpGet]
		[Route("api/car/id/{carID}")]
		public string GetCarLocation(String carID) {
			Location loc = new Location(-37.833566m, 144.793017m);
			return new JavaScriptSerializer().Serialize(loc);
		}

		// POST api/car
		public void Post([FromBody]String value) {
		}

		// PUT api/car/{id}
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/car/{id}
		public void Delete(int id) {
		}
	}
}