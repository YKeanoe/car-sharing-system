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

      // Generate car data
      cars = DatabaseReader.carQuery(null);
      // In case of database returns null use dummy data
      if (cars == null) {
        cars = new List<Car>();
        generateDummy(cars);
      }
      fillCarListHTMLRandom();
    }

    public void fillCarListHTML() {
      for (int i = 0; i < cars.Count; i++) {
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        div1.Attributes.Add("class", "panel-default car-panel");
        StringBuilder carPanelHTML = new StringBuilder();

        // TO DO
        // range placeholder.
        // Change when algorithm is finished
        String range = i + "km away";
        //int dataToggleNum = i;
        String dataToggle = "collapse-" + i;

        carPanelHTML.AppendFormat("<div class=\"panel-heading\">"
                          + "<a data-toggle=\"collapse\" href=\"#{0}\" class=\"car-panel-title\">"
                          + "{1} {2}<span style= \"float:right;\">{3}</span>"
                          + "</a> </div>"
                          + "<div id = \"{0}\" class=\"panel-collapse collapse\">"
                          + "<div class=\"panel-body\">"
                          + "asdasd asdasd"
                          + "</div></div>", dataToggle, cars[i].brand, cars[i].model, range);

        div1.InnerHtml = carPanelHTML.ToString();
        //carlist.Controls.Add(div1);
      }
    }

    public void fillCarListHTMLRandom() {

      // Clear html car list
      //carlist.Controls.Clear();
      // Grab random car from cars data
      randCars = new List<Car>();
      Random rand = new Random();
      int ran1 = rand.Next(1, 10);
      int ran2 = rand.Next(11, 20);
      int ran3 = rand.Next(21, 30);
      int ran4 = rand.Next(31, 40);
      int ran5 = rand.Next(51, 60);

      int[] randomInt = { ran1, ran2, ran3, ran4, ran5 };
      Debug.WriteLine("ran1 " + ran1);
      Debug.WriteLine("ran2 " + ran2);
      Debug.WriteLine("ran3 " + ran3);
      Debug.WriteLine("ran4 " + ran4);
      Debug.WriteLine("ran5 " + ran5);

      foreach (int i in randomInt) {
        randCars.Add(cars[i]);
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        div1.Attributes.Add("class", "panel-default car-panel");
        StringBuilder carPanelHTML = new StringBuilder();

        // TO DO
        // range placeholder.
        // Change when algorithm is finished
        String range = i + "km away";
        //int dataToggleNum = i;
        String dataToggle = "collapse-" + i;

        carPanelHTML.AppendFormat("<div class=\"panel-heading\">"
                          + "<a data-toggle=\"collapse\" href=\"#{0}\" class=\"car-panel-title\">"
                          + "{1} {2}<span style= \"float:right;\">{3}</span>"
                          + "</a> </div>"
                          + "<div id = \"{0}\" class=\"panel-collapse collapse\">"
                          + "<div class=\"panel-body\">"
                          + "asdasd asdasd"
                          + "</div></div>", dataToggle, cars[i].brand, cars[i].model, range);

        div1.InnerHtml = carPanelHTML.ToString();
        //carlist.Controls.Add(div1);
      }
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

    // Create dummy data in case database isn't working
    public void generateDummy(List<Car> cars) {
      Location latlong1 = new Location(-37.816261m, 144.970976m);
      Location latlong2 = new Location(-37.815555m, 144.970107m);
      Location latlong3 = new Location(-37.815539m, 144.966278m);
      cars.Add(new Car("V123", "Mercedes", "C Series", "Sedan", 5, 5.00, latlong1));
      cars.Add(new Car("V124", "Mercedes", "A Series", "Sedan", 5, 6.00,latlong2));
      cars.Add(new Car("V125", "Mercedes", "S Series", "Sedan", 5, 6.30, latlong3));
    }

    [System.Web.Services.WebMethod]
    public static String getData() {
      return "data";
    }
  }
}