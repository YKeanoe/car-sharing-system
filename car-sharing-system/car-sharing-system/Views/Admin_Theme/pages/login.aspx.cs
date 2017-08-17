using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Admin_Theme.login;


namespace car_sharing_system.Admin_Theme.pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            login_model data = new login_model();
            // Build your Connection
            String myData = data.dataBase("admin@gmail.com", "admin");
            if (myData != null)
                MyData.Text = myData;
        }
    }
}