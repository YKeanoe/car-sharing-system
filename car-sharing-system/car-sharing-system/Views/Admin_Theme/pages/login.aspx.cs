using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using car_sharing_system.Admin_Theme.login;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel data = new UserModel();
            // Build your Connection
            User myData = data.dataBase("admin@gmail.com", "admin");
            if (myData != null)
                MyData.Text = myData.email+" - "+myData.password;
        }
    }
}