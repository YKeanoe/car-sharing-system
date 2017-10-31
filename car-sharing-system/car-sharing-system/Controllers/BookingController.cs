using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using car_sharing_system.Models;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace car_sharing_system.Controllers {
	public class BookingController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		// Use to grab JObject or JSON from post method.
		// Convert JObject to booking object and add it to database
		public void Post([FromBody]JObject value) {
			// Use JObject since post method can't convert 2 object automatically.
			var newBookJson = value["book"];
			var locJson = value["location"];
			Location loc = new Location(
				Convert.ToDecimal(locJson["lat"]),
				Convert.ToDecimal(locJson["lng"])
				);
			Booking newBook = new Booking(
				Convert.ToInt32(newBookJson["accountID"]),
				newBookJson["numberPlate"].ToString(),
				Convert.ToInt64(newBookJson["bookingDate"].ToString()),
				Convert.ToInt64(newBookJson["startDate"].ToString()),
				Convert.ToInt64(newBookJson["estEndDate"].ToString()),
				loc);
			// Debugging
			//newBook.debug();
			
			DatabaseReader.addBooking(newBook);
			
		}

		[HttpPost]
		[Route("api/booking/finish")]
		public void PostCarLocation([FromBody] JObject value) {
			String userId = value["user_id"].ToString();
			Double distance = Convert.ToDouble(value["distance"].ToString());
			Location uloc = new Location(
				Convert.ToDecimal(value["lat"].ToString()), 
				Convert.ToDecimal(value["lng"].ToString()));

			Booking currBooking = DatabaseReader.bookingQuerySingle("accountID = '" + userId + "' AND totalCost IS NULL;");
			long endDate = currBooking.startDate + Convert.ToInt64(value["timeToEnd"].ToString());
			currBooking.endDate = endDate;
			currBooking.totalCost = currBooking.calCost(endDate);
			Double cost = (currBooking.totalCost != null) ? Convert.ToDouble(currBooking.totalCost) : 0;

			// Debugging
			//String debugging = String.Format("Finished with {0}m distance, at ({1}, {2}), for a total cost of ${3}",
			//	distance, uloc.lat, uloc.lng, cost);
			//Debug.WriteLine(debugging);
			
			DatabaseReader.finishBooking(userId, distance, currBooking.numberPlate, uloc, cost);

		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}
