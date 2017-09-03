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
    public GoogleCarLocation(String n, Location l) {
      carName = n;
      loc = l;
    }
  }

  public partial class FrontPage : System.Web.UI.Page {

    protected String coor { get { return "test"; } }
    public List<Car> cars { get; set; }
    public String carLocationsJSON { get { return passCarsForMap(); } }

    protected void Page_Load(object sender, EventArgs e) {
      // Generate dummy car data
      cars = DatabaseReader.carQuery(null);
      //List<Car> cars = new List<Car>();
      //generateDummy(cars);
            
      for (int i=0; i<cars.Count;i++) {
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
                          + "</div></div>",dataToggle, cars[i].brand, cars[i].model, range);

        div1.InnerHtml = carPanelHTML.ToString();
        carlist.Controls.Add(div1);
      }
    }

    public string passCarsForMap() {
      JavaScriptSerializer oSerializer = new JavaScriptSerializer();
      List<GoogleCarLocation> carlocs = new List<GoogleCarLocation>();

      foreach (Car car in cars) {
        carlocs.Add(new GoogleCarLocation(car.getCarAsTitle(), car.latlong));
      }

      /*for (int i = 0; i < 2; i++) {
        carlocs.Add(new GoogleCarLocation(cars[i].getCarAsTitle(), cars[i].latlong));
      }*/
      return oSerializer.Serialize(carlocs);
    }


    public void generateDummy(List<Car> cars) {
      Location latlong1 = new Location(-37.816261m, 144.970976m);
      Location latlong2 = new Location(-37.815555m, 144.970107m);
      Location latlong3 = new Location(-37.815539m, 144.966278m);
      cars.Add(new Car("V123", "Mercedes", "C Series", "Sedan", 5, 5.00, latlong1));
      cars.Add(new Car("V124", "Mercedes", "A Series", "Sedan", 5, 6.00,latlong2));
      cars.Add(new Car("V125", "Mercedes", "S Series", "Sedan", 5, 6.30, latlong3));
    }

    public String getData() {
      return "data";
    }
  }
}