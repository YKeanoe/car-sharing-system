using System;
using car_sharing_system.Models;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class adminusersview : System.Web.UI.Page
    {
        protected User newUser;

        protected void Page_Load(object sender, EventArgs e)
        {

            newUser = DatabaseReader.userQuerySingle("accountID = '" + User.Identity.Name + "';");

    
        }
    }
}