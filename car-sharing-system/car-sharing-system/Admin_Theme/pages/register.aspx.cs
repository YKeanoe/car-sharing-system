using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class register : System.Web.UI.Page
    {
        public object Email { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=acerentalsdb.cvun1f5zcjao.ap-southeast-2.rds.amazonaws.com;Database=acerentalsdb;Uid=acerentals;Pwd=password123;");
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into login values(@accountID,@email,@firstName,@licenseNo,@password,@phone)", con);
                
                cmd.Parameters.AddWithValue("email",Email.Text);

                Email.Text = "";




            }
        }
            }
    
}