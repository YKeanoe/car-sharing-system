using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace car_sharing_system.Admin_Theme.pages {

	public partial class admincar : System.Web.UI.Page {


		protected void Page_Load(object sender, EventArgs e) {
			List<Car> cars = getAllCar();

			if (cars != null && cars.Any()) {
				foreach (Car car in cars) {
					String carrow;
					String status;
					Debug.WriteLine(car.vehicleType);
					if (car.status == 'A') {
						status = "Available";
					} else if (car.status == 'B') {
						status = "Booked";
					} else {
						status = "In Use";
					}

					carrow = String.Format("<tr>"
									+ "<th>{0}</th>"
									+ "<th>{1}</th>"
									+ "<th>{2}</th>"
									+ "<th>{3}</th>"
									+ "<th>${4}</th>"
									+ "<th>{5}</th>"
									+ "<th></th>"
									+ "</tr>", car.numberPlate, car.brand, car.model, car.vehicleType,
									String.Format("{0:00.00}", car.rate),
									status);
						
					carlistph.Controls.Add(new LiteralControl(carrow));
				}
			}
		}

		public List<Car> getAllCar() {
			CarModel cm = CarModel.getInstance();
			List<Car> closeCars = cm.getAllCar();
			return closeCars;
		}

		private static String generateCarData(List<Car> cars) {
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			return oSerializer.Serialize(cars);
		}

	}
}