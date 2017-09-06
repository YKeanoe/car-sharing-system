using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using MySql.Data.MySqlClient;
using car_sharing_system.Models;

namespace car_sharing_system.Models
{
    public class DatabaseReader
    {
        static String id = "acerentals";
        static String db = "acerentalsdb";
        static String server = "acerentalsdb.cvun1f5zcjao.ap-southeast-2.rds.amazonaws.com";
        static String pass = "password123";
        static String sqlConnectionString = "Server=" + server + ";Database=" + db + ";Uid=" + id + ";Pwd=" + pass + ";";

     

        // userQuery returns a list of users from the query
        public static List<User> userQuery(String where)
        {
            List<User> users = new List<User>();
            String query;
            if (!String.IsNullOrEmpty(where))
            {
                query = "SELECT * FROM User WHERE " + where;
            }
            else
            {
                query = "SELECT * FROM User";
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader())
                {
                    while (dbread.Read())
                    {
                        User currUser = new User(Int32.Parse(dbread[0].ToString()), //accountID
                            dbread[1].ToString(),  //email
                            dbread[2].ToString(), //password
                            Int32.Parse(dbread[4].ToString()), //permission
                            dbread[3].ToString(), //licenseNo
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
                        users.Add(currUser);
                    }
                }
            }
            if (users.Count() == 0)
            {
                return null;
            }
            else
            {
                return users;
            }
        }
        // userQuerySingle return the first user found as an object.
        // return null if no user is found
        public static User userQuerySingle(String where)
        {
            String query;
            if (!String.IsNullOrEmpty(where))
            {
                query = "SELECT * FROM User WHERE " + where;
            }
            else
            {
                query = "SELECT * FROM User";
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader())
                {
                    if (dbread.Read())
                    {
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
                    else
                    {
                        return null;
                    }
                }
            }
        }
       /* public static User userQueryInsert()
        {
            String query = "INSERT TO User (accountID, email, password, permission, licenseNo, firstName, lastName, gender, birth, phone, street, suburb, postcode, territory, city, country, profileurl)";
            query += "VALUES (@userRego, @emailRego, @passwordRego, @permissionRego, @licenseNoRego, @firstRego, @lastRego, @genderRego, @birthRego, @phoneNoRego, @streetRego, @suburbRego, @postRego, @terrRego, @cityRego, @countryRego, @urlRego)";
            {


                using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))

                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlConnection.Open();

                    mySqlCommand.Parameters.Add("userRego" .Text );
                    mySqlCommand.Parameters.Add("emailRego" ,);
                    mySqlCommand.Parameters.Add("passwordRego",);
                    mySqlCommand.Parameters.Add("PermissionRego",);
                    mySqlCommand.Parameters.Add("licenseRego",);
                    mySqlCommand.Parameters.Add("firstRego",);
                    mySqlCommand.Parameters.Add("lastRego",);
                    mySqlCommand.Parameters.Add("lastRego",);
                    mySqlCommand.Parameters.Add("genderRego",);
                    mySqlCommand.Parameters.Add("birthRego",);
                    mySqlCommand.Parameters.Add("phoneNoRego",);
                    mySqlCommand.Parameters.Add("streetRego",);
                    mySqlCommand.Parameters.Add("suburbRego",);
                    mySqlCommand.Parameters.Add("postRego",);
                    mySqlCommand.Parameters.Add("terrRego",);
                    mySqlCommand.Parameters.Add("cityRego",);
                    mySqlCommand.Parameters.Add("countryRego",);
                    mySqlCommand.Parameters.Add("urlRego",);             
                    mySqlCommand.ExecuteNonQuery();
                }
            }

        }
        */


        public static List<Car> carQuery(String where) {
      Debug.WriteLine("car query");
      String query;
      List<Car> cars = new List<Car>();
      if (!String.IsNullOrEmpty(where)) {
        query = "SELECT * FROM Car WHERE " + where;
      } else {
        query = "SELECT * FROM Car";
      }

            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

        using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
          while (dbread.Read()) {
            Location newLocation = new Location(
                             Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
                             Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
            Car newCar = new Car(dbread[0].ToString() /*ID / license plate*/,
                             dbread[4].ToString() /*Brand*/,
                             dbread[5].ToString() /*Model*/,
                             dbread[6].ToString() /*Vehicle type*/,
                             Int32.Parse(dbread[7].ToString()) /*Seats number*/,
                             Convert.ToDouble(dbread[14].ToString()) /*Hourly rate*/,
                             newLocation);
            cars.Add(newCar);
            newCar.debug();
          }
        }
        mySqlConnection.Close();
      }
      if (cars.Count() == 0) {
        return null;
      } else {
        return cars;
      }
    }

        public static Car carQuerySingle(String where)
        {
            String query;
            if (!String.IsNullOrEmpty(where))
            {
                query = "SELECT * FROM Car WHERE " + where;
            }
            else
            {
                query = "SELECT * FROM Car";
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

        using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
          if (dbread.Read()) {
            Location newLocation = new Location(
                              Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
                              Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
            return new Car(dbread[0].ToString() /*ID / license plate*/,
                             dbread[4].ToString() /*Brand*/,
                             dbread[5].ToString() /*Model*/,
                             dbread[6].ToString() /*Vehicle type*/,
                             Int32.Parse(dbread[7].ToString()) /*Seats number*/,
                             Convert.ToDouble(dbread[14].ToString()) /*Hourly rate*/,
                             newLocation);
          }
          else {
            return null;
          }
        }
      }
    }
  }
}