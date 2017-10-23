using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using car_sharing_system.Models;
using System.Diagnostics;
using Newtonsoft.Json.Linq;


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
			List<Car> closeCars = CarModel.getCloseCarAPI(-37.813600, 144.963100, amount);
			List<String> aCars = new List<String>();
			foreach (Car car in closeCars) {
				aCars.Add(car.numberPlate);
			}
			return new JavaScriptSerializer().Serialize(aCars);
		}

		// GET api/car/id/{carID}
		// Use car number plate to find the car and return the car's current location.
		[HttpGet]
		[Route("api/car/id/{carID}")]
		public string GetCarLocation(String carID) {
			Car car = DatabaseReader.carQuerySingle("numberPlate = '" + carID + "'");
			//Location loc = new Location(-37.833566m, 144.793017m);
			return new JavaScriptSerializer().Serialize(car.latlong);
		}

		// POST api/car
		public void Post([FromBody]String value) {
		}

		[HttpPost]
		[Route("api/car/id/{carID}")]
		public void PostCarLocation(String carID, [FromBody] JObject value) {
			Location loc = new Location(
								Convert.ToDecimal(value["lat"]),
								Convert.ToDecimal(value["lng"])
								);
			DatabaseReader.updateCarLocation(carID, loc);
		}

		// PUT api/car/{id}
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/car/{id}
		public void Delete(int id) {
		}
	}
}