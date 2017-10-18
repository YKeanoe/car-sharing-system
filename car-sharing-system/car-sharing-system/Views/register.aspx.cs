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
        protected User newUser;
       

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
            newUser = new User(emailRego.Text, passwordRego.Text, 0, licenseRego.Text, firstRego.Text, lastNameRego.Text, 
                RadioButtonList1.Text, birthRego.Text, phoneNoRego.Text, streetRego.Text, suburbRego.Text, postRego.Text, terrRego.Text,
                cityRego.Text, countryRego.Text, "");
			newUser.changePassword(newUser.hashMe(passwordRego.Text));

            if (newUser.nullChecker())
            {
                if (DatabaseReader.userQuerySingle(" '"+ newUser.email+ "' = email OR '" + newUser.licenseNo + "' = licenseNo LIMIT 1") == null) {
                    DatabaseReader.Registeration(newUser);
                    User curr = DatabaseReader.userQuerySingle("email = '" + newUser.email + "';");

					//FormsAuthentication.SetAuthCookie(curr.id.ToString(), false);

					FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
						  curr.id.ToString(), // userID
						  DateTime.Now,
						  DateTime.Now.AddMinutes(30),
						  false, // rememberme tick
						  curr.permission.ToString(), // user permission 
						  FormsAuthentication.FormsCookiePath);

					// Encrypt the ticket.
					string encTicket = FormsAuthentication.Encrypt(ticket);

					// Create the cookie.
					Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

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
            
    
