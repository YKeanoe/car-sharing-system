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
            String pathBefore;
            if (Request.UrlReferrer != null) {
                pathBefore = Request.UrlReferrer.ToString();
			} else {
				pathBefore = "";
			}

			//Debug.WriteLine(path);
			if (pathBefore != null) {
				//Debug.WriteLine(pathBefore);
			}

			// If the page is not login page
			if (!path.Equals("/dashboard/login")) {
				// If the page is booking confirmation page
				if (path.Equals("/dashboard/confirmation")) {
					String id = Request.QueryString["id"];
					int sdate = Int32.Parse(Request.QueryString["sdate"]);
					int edate = Int32.Parse(Request.QueryString["edate"]);

					if (!Request.IsAuthenticated) {
						Response.Redirect("~/dashboard/login?redirect=" + path + "&id=" + id + "&sdate=" + sdate + "&edate=" + edate);
					}
				} else if (path.Equals("/dashboard/register")) {
					// Do nothing.
				} else {
					if (!Request.IsAuthenticated) {
						Response.Redirect("~/dashboard/login?redirect=" + path);
					}
				}
			} else {
				if (Request.IsAuthenticated) {
					Response.Redirect("/dashboard");
				}
			}
		}
	}
}