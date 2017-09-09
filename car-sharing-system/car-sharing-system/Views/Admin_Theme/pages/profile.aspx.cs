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
        protected String fn;
        protected String ln;
        protected String licenceNo;
        protected String birth;
        protected String gender;
        protected String phone;
        protected String street;
        protected String suburb;
        protected String postcode;
        protected String territory;
        protected String city;
        protected String country;
        protected String profileURL;


        protected void Page_Load(object sender, EventArgs e)
        {

            newUser = DatabaseReader.userQuerySingle("accountID = '" +  User.Identity.Name + "';");

            fn = newUser.fname;
            ln = newUser.lname;
            licenceNo = newUser.licenceNo;
            birth = newUser.birth;
            gender = newUser.gender;
            phone = newUser.phone;
            street = newUser.street;
            suburb = newUser.suburb;
            postcode = newUser.postcode;
            territory = newUser.territory;
            city = newUser.city;
            country = newUser.country;
            profileURL = newUser.profileURL;

      if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Views/Admin_Theme/pages/login.aspx");
            }
        }
    }
}