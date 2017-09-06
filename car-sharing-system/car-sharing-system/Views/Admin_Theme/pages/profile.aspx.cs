using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class profile : System.Web.UI.Page
    {
        protected User newUser;
        protected void Page_Load(object sender, EventArgs e)
        {

            newUser = DatabaseReader.userQuerySingle("accountID = '" +  User.Identity.Name + "';");

<<<<<<< HEAD
  
=======
            fn.Text += newUser.fname;
            ln.Text += newUser.lname;
            LicenceNo.Text += newUser.LicenceNo;
            dob.Text += newUser.dob;


>>>>>>> parent of 3478442... Merge branch 'dev' of https://github.com/rmit-s3323595-yohanes-keanoe/car-sharing-system.git

            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Views/Admin_Theme/pages/login.aspx");
            }
        }
    }
}