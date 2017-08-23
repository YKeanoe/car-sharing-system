using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace car_sharing_system.Models
{
  public class DatabaseReader {
    static String id = "acerentals";
    static String db = "acerentalsdb";
    static String server = "acerentalsdb.cvun1f5zcjao.ap-southeast-2.rds.amazonaws.com";
    static String pass = "password123";
    static String sqlConnectionString = "Server=" + server + ";Database=" + db + ";Uid=" + id + ";Pwd=" + pass + ";";
    
    // userQuery returns a list of users from the query
    public static List<User> userQuery(String where) {
      List<User> users = new List<User>();
      String query;
      if (String.IsNullOrEmpty(where)) {
        query = "SELECT * FROM User WHERE " + where;
      } else {
        query = "SELECT * FROM User";
      }

      using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)){
        mySqlConnection.Open();
        MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

        using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
          while (dbread.Read()) {
            User currUser = new User(Int32.Parse(dbread[0].ToString()), dbread[1].ToString(), dbread[2].ToString(),
                Int32.Parse(dbread[3].ToString()), dbread[4].ToString(), dbread[5].ToString(),
                dbread[6].ToString(), dbread[7].ToString(), dbread[8].ToString(), dbread[9].ToString());
            users.Add(currUser);
          } 
        }
      }
      return users;
    }

    public static User userQuerySingle(String where)
    {
      String query;
      if (String.IsNullOrEmpty(where)) {
        query = "SELECT * FROM User WHERE " + where;
      } else {
        query = "SELECT * FROM User";
      }

      using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
        mySqlConnection.Open();
        MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

        using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
          if (dbread.Read()) {
            return new User(Int32.Parse(dbread[0].ToString()), dbread[1].ToString(), dbread[2].ToString(),
                Int32.Parse(dbread[3].ToString()), dbread[4].ToString(), dbread[5].ToString(),
                dbread[6].ToString(), dbread[7].ToString(), dbread[8].ToString(), dbread[9].ToString());
          }
          else {
            return null;
          }
        }
      }
    }

    public User loginAttempt(String email, String password)
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
        using (MySqlDataReader dbread = mySqlCommand.ExecuteReader())
        {
          // If your reader can read
          if (dbread.Read())
          {
            // Set your label to the first value available
            //FailureText.Text = dbread[0].ToString();
            User currUser = new User(Int32.Parse(dbread[0].ToString()), dbread[1].ToString(), dbread[2].ToString(),
                Int32.Parse(dbread[3].ToString()), dbread[4].ToString(), dbread[5].ToString(),
                dbread[6].ToString(), dbread[7].ToString(), dbread[8].ToString(), dbread[9].ToString());

            return currUser;
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