using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Text;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Web.Script.Services;

namespace car_sharing_system
{
  public class Users
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
  }

  public class GoogleCarLocation {
    public String carName { get; set; }
    public Location loc { get; set; }
    public int dist { get; set; }
    public GoogleCarLocation(String n, Location l, int d) {
      carName = n;
      loc = l;
      dist = d;
    }
  }

  public partial class FrontPage : System.Web.UI.Page {
    // Cars data
    public static List<Car> cars { get; set; }
    // Random cars data
    public static List<Car> randCars { get; set; }

    protected void Page_Load(object sender, EventArgs e) {
			CarModel cm = CarModel.getInstance();
			cm.refreshCars();
    }

    public static void getRandomCars() {
      // Grab random car from cars data
      randCars = new List<Car>();
      Random rand = new Random();
      int ran1 = rand.Next(1, 10);
      int ran2 = rand.Next(11, 20);
      int ran3 = rand.Next(21, 30);
      int ran4 = rand.Next(31, 40);
      int ran5 = rand.Next(51, 60);

      int[] randomInt = { ran1, ran2, ran3, ran4, ran5 };
      Debug.WriteLine(ran1 + ", " + ran2 + ", " + ran3 + ", " + ran4 + ", " + ran5);

      foreach (int i in randomInt) {
        randCars.Add(cars[i]);
      }
    }

    [System.Web.Services.WebMethod]
    public static string getCarsData() {
      JavaScriptSerializer oSerializer = new JavaScriptSerializer();
      List<GoogleCarLocation> carlocs = new List<GoogleCarLocation>();
      //fillCarListHTMLRandom();
      getRandomCars();
      // Change to bellow for which cars to use
      Random rand = new Random();
      foreach (Car car in randCars) {
        carlocs.Add(new GoogleCarLocation(car.getCarAsTitle(), car.latlong, rand.Next(1,50)));
      }

      /*for (int i = 0; i < 2; i++) {
        carlocs.Add(new GoogleCarLocation(cars[i].getCarAsTitle(), cars[i].latlong));
      }*/
      return oSerializer.Serialize(carlocs);
    }
  }
}