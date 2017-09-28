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
                Label1.Text = newUser.fname;
                Label1.Style.Add("font-weight", "bold");
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