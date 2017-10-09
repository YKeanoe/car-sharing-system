using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Text;

namespace car_sharing_system.Admin_Theme.pages {

	public partial class admincar : System.Web.UI.Page {


		protected void Page_Load(object sender, EventArgs e) {}

		[System.Web.Services.WebMethod]
		public static int getCarPageCount() {
			CarModel cm = CarModel.getInstance();
			List<Car> cars = cm.getAllCar();
			int carpages = cm.countPages(50);
			return carpages;
		}

		[System.Web.Services.WebMethod]
		public static string getCarPage(int page) {
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			CarModel cm = CarModel.getInstance();
			List<Car> cars = cm.getPageAllCar(page);
			return oSerializer.Serialize(stringifyCars(cars));
		}

		private static List<String> stringifyCars(List<Car> cars) {
			List<String> carhtml = new List<String>();
			if (cars != null && cars.Any()) {
				foreach (Car car in cars) {
					String status;
					String html;
					if (car.status == 'A') {
						status = "Available";
					} else if (car.status == 'B') {
						status = "Booked";
					} else {
						status = "In Use";
					}
					html = String.Format("<tr>"
									+ "<td>{0}</td>"
									+ "<td>{1}</td>"
									+ "<td>{2}</td>"
									+ "<td>{3}</td>"
									+ "<td>${4}</td>"
									+ "<td>{5}</td>"
									+ "<td><a class=\"btn btn-primary\" href=\"/dashboard/admin/\" role=\"button\">Car Detail</a></td>"
									+ "</tr>", car.numberPlate, car.brand, car.model, car.vehicleType,
									String.Format("{0:00.00}", car.rate),
									status);
					carhtml.Add(html);
				}
			}
			return carhtml;
		}

		private void setpages(int pages) {
			StringBuilder pagesb = new StringBuilder();
			for (int i = 2; i <= pages; i++) {
				pagesb.Append("<li><a href=\"javascript:void(0);\"> " + i + "</a></li>");
			}
			//pagination.Controls.Add(new LiteralControl(pagesb.ToString()));
		}

		private static String generateCarData(List<Car> cars) {
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			return oSerializer.Serialize(cars);
		}

	}
}