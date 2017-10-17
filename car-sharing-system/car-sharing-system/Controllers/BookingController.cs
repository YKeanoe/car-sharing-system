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
			newBook.debug();

			// TO DO
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}


	public class test {
		String title;
		String value;
		public test(String title, String value) {
			this.title = title;
			this.value = value;
		}
		public void debug() {
			Debug.WriteLine("title: " + title);
			Debug.WriteLine("value: " + value);
		}
	}
}
