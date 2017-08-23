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

namespace car_sharing_system
{
  public class Users
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
  }
  public partial class FrontPage : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
      // Generate dummy car data
      List<Car> cars = new List<Car>();
      generateDummy(cars);

      for(int i=0; i<cars.Count;i++) {
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        div1.Attributes.Add("class", "panel-default car-panel");
        StringBuilder carPanelHTML = new StringBuilder();

        // range placeholder
        String range = i + "km away";
        int dataToggleNum = i + 3;
        String dataToggle = "collapse" + dataToggleNum;

        carPanelHTML.AppendFormat("<div class=\"panel-heading\">"
                          + "<a data-toggle=\"collapse\" href=\"#{0}\" class=\"car-panel-title\">"
                          + "{1}<span style= \"float:right;\">{2}</span>"
                          + "</a> </div>"
                          + "<div id = \"{0}\" class=\"panel-collapse collapse\">"
                          + "<div class=\"panel-body\">"
                          + "asdasd asdasd"
                          + "</div></div>",dataToggle, cars[i].model, range);

        div1.InnerHtml = carPanelHTML.ToString();
        carlist.Controls.Add(div1);
      }
    }

    public void generateDummy(List<Car> cars) {
      cars.Add(new Car("V123", "Mercedes", "C Series", "Sedan", 5, 5.00, -37.816261, 144.970976));
      cars.Add(new Car("V124", "Mercedes", "A Series", "Sedan", 5, 6.00, -37.815555, 144.970107));
      cars.Add(new Car("V125", "Mercedes", "S Series", "Sedan", 5, 6.30, -37.815539, 144.966278));
    }
  }
}