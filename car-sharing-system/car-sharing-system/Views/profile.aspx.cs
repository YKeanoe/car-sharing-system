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
                efirstname.Value = newUser.fname;
                elastname.Value = newUser.lname;
                elicenseNo.Value = newUser.licenseNo;
                ephone.Value = newUser.phone;
                estreet.Value = newUser.street;
                esuburb.Value = newUser.suburb;
                ecity.Value = newUser.city;
                eterritory.Value = newUser.territory;
                eprofileURL.Value = newUser.profileURL;
                epostcode.Value = newUser.postcode;
                egender.Value = newUser.gender;
                ebirth.Value = newUser.birth;
            }
            else
            {
                showData.Visible = true;
                updateform.Visible = false;
                fN.InnerText = newUser.fname ;
                lN.InnerText = newUser.lname;
                LiN.InnerText = newUser.licenseNo;
                ph.InnerText = newUser.phone;
                st.InnerText = newUser.street;
                sb.InnerText = newUser.suburb;
                ci.InnerText = newUser.city;
                ter.InnerText = newUser.territory;
                pu.Src = newUser.profileURL;
                pc.InnerText = newUser.postcode;
                gen.InnerText = newUser.gender;
                dob.InnerText = newUser.birth;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            newUser = DatabaseReader.userQuerySingle("accountID = '" + User.Identity.Name + "';");
            newUser.fname = efirstname.Value;
            newUser.lname = elastname.Value;
            newUser.licenseNo = elicenseNo.Value;
            newUser.phone = ephone.Value;
            newUser.street = estreet.Value;
            newUser.suburb = esuburb.Value;
            newUser.city = ecity.Value;
            newUser.territory = eterritory.Value;
            newUser.profileURL = eprofileURL.Value;
            newUser.postcode = epostcode.Value;
            newUser.gender = egender.Value;
            newUser.birth = ebirth.Value;
            DatabaseReader.updateProfile(newUser);

            Response.Redirect("/dashboard/profile?updated=1");
        }
    }
}