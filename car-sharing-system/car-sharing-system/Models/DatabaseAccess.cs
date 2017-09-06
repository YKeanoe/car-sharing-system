using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{
    public class DatabaseAccess
    {
        private MySqlConnection mySqlConnection = new MySqlConnection("Server=acerentalsdb.cvun1f5zcjao.ap-southeast-2.rds.amazonaws.com;Database=acerentalsdb;Uid=acerentals;Pwd=password123;");
        public DatabaseAccess() {

        }
        public MySqlDataReader queryDatabase(String sql) {
            mySqlConnection.Open();

            // Build your command to execute
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            // Execute your query
            MySqlDataReader dbread = mySqlCommand.ExecuteReader();

            mySqlConnection.Close();

            return dbread;
        }
    }
}