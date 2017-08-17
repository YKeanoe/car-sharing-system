using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Admin_Theme.login
{
    public class login_model
    {
        public login_model() {

        }

        public String dataBase(String email, String password)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection("Server=acerentalsdb.cvun1f5zcjao.ap-southeast-2.rds.amazonaws.com;Database=acerentalsdb;Uid=acerentals;Pwd=password123;"))
            {
                // Now that you have your connection, build your query
                var sql = "SELECT * FROM User WHERE email = @email AND password= @password";

                // Open your connection
                mySqlConnection.Open();

                // Build your command to execute
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);

                // Add your parameter
                mySqlCommand.Parameters.AddWithValue("@email", email);
                mySqlCommand.Parameters.AddWithValue("@password", password);

                // Execute your query
                using (var dbread = mySqlCommand.ExecuteReader())
                {
                    // If your reader can read
                    if (dbread.Read())
                    {
                        // Set your label to the first value available
                        //FailureText.Text = dbread[0].ToString();
                        return dbread[0].ToString()+" - "+dbread[1].ToString()+" - "+dbread[2].ToString();
                    }
                    else
                    {
                        // Otherwise return nothing
                        return null;
                    }
                }
            }
        }
    }
}