using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class adminissueview : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

            User newUser = DatabaseReader.userQuerySingle("accountID = '" + User.Identity.Name + "';");


    
        }
    }
}