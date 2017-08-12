using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Web.UI.HtmlControls;

namespace car_sharing_system
{
  public class User
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
  }
  public partial class FrontPage : System.Web.UI.Page {
    ArrayList cars = new ArrayList();
    protected void Page_Load(object sender, EventArgs e) {
  //    generateDummy();
      var collections = new List<User>
        {
            new User {Name = "Jon Doe", Email = "john@doe.com", Phone = "123-123-1234"},
            new User {Name = "Marry Doe", Email = "marry@doe.com", Phone = "456-456-4567"},
            new User {Name = "Eric Newton", Email = "eric@newton.com", Phone = "789-789-7890"},
        };
      //      CarGridView.DataSource = collections;
      //    CarGridView.DataBind();

      int i = 0;
      while (i < 3) {
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        div1.ID = "div"+i;
        div1.InnerHtml = "This is a dynamically created HTML server control " + i;
        carlist.Controls.Add(div1);
        i++;
      }

    }
    public void generateDummy() {
      cars.Add(new Car("V123", "Mercedes", "C Series", "Sedan", 5, 5.00, -37.816261, 144.970976));
      cars.Add(new Car("V124", "Mercedes", "A Series", "Sedan", 5, 6.00, -37.815555, 144.970107));
      cars.Add(new Car("V125", "Mercedes", "S Series", "Sedan", 5, 6.30, -37.815539, 144.966278));
    }
  }
}