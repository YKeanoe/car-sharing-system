using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Web.Security;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class register : System.Web.UI.Page
    {
        protected user newUser;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            //be validation
            //check if existing email n license n phoneno 
            if (Request.IsAuthenticated)
            {
                Response.Redirect("/dashboard/");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DatabaseReader dr = new DatabaseReader();
 
            newUser = new user(-1 ,emailRego.Text, passwordRego.Text, 0, licenseRego.Text, firstRego.Text, lastNameRego.Text, 
                RadioButtonList1.Text, birthRego.Text, phoneNoRego.Text, streetRego.Text, suburbRego.Text, postRego.Text, terrRego.Text,
                cityRego.Text, countryRego.Text, "");

            if (newUser.nullChecker())
            {
                if (DatabaseReader.userQuerySingle(" '"+ newUser.email+ "' = email OR '" + newUser.licenseNo + "' = licenseNo LIMIT 1") == null) {
                    dr.Registeration(newUser);
                    user curr = DatabaseReader.userQuerySingle("email = '" + newUser.email + "';");
                    FormsAuthentication.SetAuthCookie(curr.id.ToString(), false);
                    Response.Redirect("/dashboard/");
                }else
                {
                    regFail.InnerText = "Email or license Number already used";
                }
            }
            else {
                regFail.InnerText = "Please enter all required data";
            }
        }
    }
}
            
    
