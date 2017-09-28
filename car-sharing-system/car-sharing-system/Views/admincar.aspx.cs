using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class admincar : System.Web.UI.Page
    {
        protected String fn;
        protected String ln;
        protected String licenseNo;
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

            User newUser = DatabaseReader.userQuerySingle("accountID = '" + User.Identity.Name + "';");

        }
    }
}