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

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class register : System.Web.UI.Page
    {
        protected User newUser;
       

        protected void Page_Load(object sender, EventArgs e)
        {
         //be validation
         //check if existing email n license n phoneno 
         
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DatabaseReader dr = new DatabaseReader();

            newUser = new User(-1 ,emailRego.Text, passwordRego.Text, 0, licenseRego.Text, firstRego.Text, lastNameRego.Text, 
                RadioButtonList1.Text, birthRego.Text, phoneNoRego.Text, streetRego.Text, suburbRego.Text, postRego.Text, terrRego.Text,
                cityRego.Text, countryRego.Text, urlRego.Text);

            dr.Registeration(newUser);
            



            Response.Redirect("successIssue.aspx");


        }
        
    }
}
            
    
