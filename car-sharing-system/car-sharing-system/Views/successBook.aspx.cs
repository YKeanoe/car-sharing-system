using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace car_sharing_system.Views.pages
{
	public partial class successBook : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			String lt = Request.QueryString["lat"];
			String lg = Request.QueryString["lng"];
			decimal lat, lng;
			if (!String.IsNullOrEmpty(lt) && !String.IsNullOrEmpty(lg)) {
				lat = Convert.ToDecimal(lt);
				lng = Convert.ToDecimal(lg);
				
			}
			latlonglabel.Text = lt + ", " + lg;
		}
	}
}