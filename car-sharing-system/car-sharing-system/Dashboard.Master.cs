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
      string path = HttpContext.Current.Request.Url.AbsolutePath;
      Debug.WriteLine(path);
      if (!path.Equals("/dashboard/login")) {
        if (!Request.IsAuthenticated) {
          Response.Redirect("~/dashboard/login");
        }
      } else {
        if (Request.IsAuthenticated) {
          Response.Redirect("~/dashboard");
        }
      }
    }
  }
}