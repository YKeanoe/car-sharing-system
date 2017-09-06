using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;


namespace car_sharing_system.Admin_Theme.pages
{
    public partial class register : System.Web.UI.Page
    {

        protected User newUser;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            newUser = DatabaseReader.userQueryInsert("accountID = '" + User.Identity.Name + "';");

           
        }
        }
        }
            
    
