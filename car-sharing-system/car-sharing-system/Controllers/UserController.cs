using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using car_sharing_system.Models;

namespace car_sharing_system.Controllers {
	public class UserController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/car/{amount}
		// Use amount as to the amount of users requested
		// Return user ids without booking as a list.
		[Route("api/user/{amount}")]
		public string Get(int amount) {
			List<int> ids = new List<int>(new int[] { 1, 2, 3, 4 });
			return new JavaScriptSerializer().Serialize(ids);
		}

		// POST api/<controller>
		public void Post([FromBody]string value) {
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}