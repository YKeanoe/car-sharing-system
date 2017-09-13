using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using MySql.Data.MySqlClient;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class issue : System.Web.UI.Page
    {
        protected Issues newIssue;
       

       

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            DatabaseReader dr = new DatabaseReader();
            newIssue = new Issues(-1,-1,-1,-1,-1,subjectIssue.Text, description.Text);

            dr.Issue(newIssue);

            Response.Redirect("successIssue.aspx");

        }
    }
}