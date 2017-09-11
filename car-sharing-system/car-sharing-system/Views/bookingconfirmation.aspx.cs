using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace car_sharing_system.Views.Admin_Theme.pages
{
	public partial class bookingconfirmation : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			String id = Request.QueryString["id"];
			Session["fml"] = "fmlll";
			//Session.Timeout = 7;
			if (id != null) {
				Session["carid"] = id;
			}

		}


	}
}