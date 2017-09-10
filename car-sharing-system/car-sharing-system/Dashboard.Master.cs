using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace car_sharing_system {
  public partial class Dashboard : System.Web.UI.MasterPage {

    protected void Page_Load(object sender, EventArgs e) {
      String path = HttpContext.Current.Request.Url.AbsolutePath;
      String pathBefore = Request.UrlReferrer.ToString();

      //Debug.WriteLine(path);
      if (pathBefore != null) {
        //Debug.WriteLine(pathBefore);
      }


      // If the page is login page
      if (!path.Equals("/dashboard/login")) {
        // If the page is booking confirmation page with the car's id
        if (path.Equals("/dashboard/confirmation")) {
          String id = Request.QueryString["id"];
          if (!Request.IsAuthenticated) {
            Response.Redirect("~/dashboard/login?id="+id);
          }
        } else {
          if (!Request.IsAuthenticated) {
            Response.Redirect("~/dashboard/login");
          }
        }
      } else {
        if (Request.IsAuthenticated) {
          Response.Redirect("~/dashboard");
        }
      }
    }

  }
}