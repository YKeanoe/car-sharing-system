using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using car_sharing_system.Models;

namespace car_sharing_system.Controllers {
	public class CarController : System.Web.Http.ApiController {
		// GET api/car
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/car/{id}
		public string Get(int id) {
			Location loc = new Location(11111m, 22222m);
			return loc.ToJson();
		}

		// POST api/car
		public void Post([FromBody]string value) {
		}

		// PUT api/car/{id}
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/car/{id}
		public void Delete(int id) {
		}
	}
}