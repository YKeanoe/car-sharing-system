using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace car_sharing_system.Models
{
	public class Location
	{
		public decimal lat { get; set; }
		public decimal lng { get; set; }

		public Location(decimal coorX, decimal coorY)
		{
			this.lat = coorX;
			this.lng = coorY;
		}

		public void debug()
		{
			System.Diagnostics.Debug.WriteLine(lat.ToString() + "," + lng.ToString());
		}

		public override String ToString() {
			return lat.ToString() + "," + lng.ToString();
		}

		public String ToJson() {
			return new JavaScriptSerializer().Serialize(this);
		}
  }
}