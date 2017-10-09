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
    public partial class issue : System.Web.UI.Page
    {
        protected Issue newIssue;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (subjectIssue.Text.Equals(null) || description.Text.Equals(null))
            {
                issueFail.InnerText = "Please fill out the whole form.";
            }
            else
            {

                DatabaseReader dr = new DatabaseReader();

                newIssue = new Issue(Int32.Parse(User.Identity.Name), subjectIssue.Text, description.Text);

                dr.clientIssue(newIssue);

                Response.Redirect("~/dashboard/issuereported");
            }
        }
    }
}