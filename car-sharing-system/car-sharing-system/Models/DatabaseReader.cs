using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using car_sharing_system.Models;

namespace car_sharing_system.Models {
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
      if (!String.IsNullOrEmpty(where)) {
        query = "SELECT * FROM User WHERE " + where;
      } else {
        query = "SELECT * FROM User";
      }

      using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
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
      if (users.Count() == 0) {
        return null;
      }
      else {
        return users;
      }
    }
    // userQuerySingle return the first user found as an object.
    // return null if no user is found
    public static User userQuerySingle(String where) {
      String query;
      if (!String.IsNullOrEmpty(where)) {
        query = "SELECT * FROM User WHERE " + where;
      } else {
        query = "SELECT * FROM User";
      }

      using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
        mySqlConnection.Open();
        MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

        using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
          if (dbread.Read()) {
<<<<<<< HEAD
<<<<<<< HEAD
            return new User(Int32.Parse(dbread[0].ToString()), //accountID
                            dbread[1].ToString(),  //email
                            dbread[2].ToString(), //password
                            Int32.Parse(dbread[3].ToString()), //permission
                            dbread[4].ToString(), //licenseNo
                            dbread[5].ToString(), //firstName
                            dbread[6].ToString(), //lastName
                            dbread[7].ToString(), //gender
                            dbread[8].ToString(), //birth
                            dbread[9].ToString(), //phone
                            dbread[10].ToString(), //street
                            dbread[11].ToString(), //suburb
                            dbread[12].ToString(), //postcode
                            dbread[13].ToString(), //territory
                            dbread[14].ToString(), //city
                            dbread[15].ToString(), //country
                            dbread[16].ToString()); //profileurl
                    }
=======
=======
>>>>>>> parent of 3478442... Merge branch 'dev' of https://github.com/rmit-s3323595-yohanes-keanoe/car-sharing-system.git
            return new User(Int32.Parse(dbread[0].ToString()), dbread[1].ToString(), dbread[2].ToString(),
                Int32.Parse(dbread[3].ToString()), dbread[4].ToString(), dbread[5].ToString(),
                dbread[6].ToString(), dbread[7].ToString(), dbread[8].ToString(), dbread[9].ToString());
          }
<<<<<<< HEAD
>>>>>>> parent of 3478442... Merge branch 'dev' of https://github.com/rmit-s3323595-yohanes-keanoe/car-sharing-system.git
=======
>>>>>>> parent of 3478442... Merge branch 'dev' of https://github.com/rmit-s3323595-yohanes-keanoe/car-sharing-system.git
          else {
            return null;
          }
        }
      }
    }

    
    public static List<Car> carQuery(String where) {
      String query;
      List<Car> cars = new List<Car>();
      if (!String.IsNullOrEmpty(where)) {
        query = "SELECT * FROM Car WHERE " + where;
      } else {
        query = "SELECT * FROM Car";
      }

      using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
        mySqlConnection.Open();
        MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

        using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
          while (dbread.Read()) {
            Car newCar = new Car(dbread[0].ToString() /*ID / license plate*/,
                             dbread[3].ToString() /*Brand*/,
                             dbread[4].ToString() /*Model*/,
                             dbread[5].ToString() /*Vehicle type*/,
                             Int32.Parse(dbread[6].ToString()) /*Seats number*/,
                             Convert.ToDouble(dbread[7].ToString()) /*Hourly rate*/,
                             Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
                             Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
            cars.Add(newCar);
          }
        }
      }
      if (cars.Count() == 0) {
        return null;
      } else {
        return cars;
      }
    }

    public static Car carQuerySingle(String where) {
      String query;
      if (!String.IsNullOrEmpty(where)) {
        query = "SELECT * FROM Car WHERE " + where;
      } else {
        query = "SELECT * FROM Car";
      }

      using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
        mySqlConnection.Open();
        MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

        using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
          if (dbread.Read()) {
            return new Car(dbread[0].ToString() /*ID / license plate*/,
                           dbread[3].ToString() /*Brand*/,
                           dbread[4].ToString() /*Model*/,
                           dbread[5].ToString() /*Vehicle type*/,
                           Int32.Parse(dbread[6].ToString()) /*Seats number*/,
                           Convert.ToDouble(dbread[7].ToString()) /*Hourly rate*/,
                           Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
                           Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
          }
          else {
            return null;
          }
        }
      }
    }
  }
}