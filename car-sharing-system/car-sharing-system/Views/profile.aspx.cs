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
            newUser = DatabaseReader.userQuerySingle("accountID = '" + User.Identity.Name + "';");

            if (Request.QueryString["edit"] == "1")
            {
                showData.Visible = false;
                updateform.Visible = true;
            }
            else
            {
                showData.Visible = true;
                updateform.Visible = false;
                firstname.Value = newUser.fname ;
                lastname.Value = newUser.lname;
                licenseNo.Value = newUser.licenseNo;
                phone.Value = newUser.phone;
                street.Value = newUser.street;
                suburb.Value = newUser.suburb;
                city.Value = newUser.city;
                territory.Value = newUser.territory;
                profileURL.Value = newUser.profileURL;
                postcode.Value = newUser.postcode;
                gender.Value = newUser.gender;
                birth.Value = newUser.birth;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            newUser = DatabaseReader.userQuerySingle("accountID = '" + User.Identity.Name + "';");
            newUser.fname = firstname.Value;
            newUser.lname = lastname.Value;
            newUser.licenseNo = licenseNo.Value;
            newUser.phone = phone.Value;
            newUser.street = street.Value;
            newUser.suburb = suburb.Value;
            newUser.city = city.Value;
            newUser.territory = territory.Value;
            newUser.profileURL = profileURL.Value;
            newUser.postcode = postcode.Value;
            newUser.gender = gender.Value;
            newUser.birth = birth.Value;
            DatabaseReader.updateProfile(newUser);

            Response.Redirect("/dashboard/profile?updated=1");
        }
    }
}