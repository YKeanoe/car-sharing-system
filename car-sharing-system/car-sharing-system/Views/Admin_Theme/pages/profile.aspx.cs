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
        protected void Page_Load(object sender, EventArgs e)
        {

            User newUser = DatabaseReader.userQuerySingle("accountID = '" +  User.Identity.Name + "';");

            fn.Text += newUser.fname;
            ln.Text += newUser.lname;
            licenceNo.Text += newUser.licenceNo;
            birth.Text += newUser.birth;
            gender.Text += newUser.gender;
            phone.Text += newUser.phone;
            street.Text += newUser.street;
            suburb.Text += newUser.suburb;
            postcode.Text += newUser.postcode;
            territory.Text += newUser.territory;
            city.Text += newUser.city;
            country.Text += newUser.country;
            profileURL.Text += newUser.profileURL;

            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Views/Admin_Theme/pages/login.aspx");
            }
        }
    }
}