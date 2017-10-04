using System;
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