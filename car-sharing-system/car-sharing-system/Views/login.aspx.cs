using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using Rework;
using System.Diagnostics;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class login : System.Web.UI.Page
    {

		String redirect;

        protected void Page_Load(object sender, EventArgs e) {

			redirect = Request.QueryString["redirect"];

			// I don't think this do anything
			// Login1.DestinationPageUrl = "/dashboard/profile";
        }
        protected void ValidateUser(object sender, EventArgs e)
        {
            UserModel data = new UserModel();
            String password = (Login1.Password+"CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            User myData = data.loginAttempt(Login1.UserName, password);
            if (myData != null)
            {
				//FormsAuthentication.RedirectFromLoginPage(myData.id.ToString(), Login1.RememberMeSet);

				FormsAuthentication.SetAuthCookie(myData.id.ToString(), Login1.RememberMeSet);
				if (redirect != null) {
					Response.Redirect(redirect);
				} else {
					Response.Redirect("/dashboard/");
				}
			}
            else
            {
                Login1.FailureText = password;
            }
        
        }

    }
}