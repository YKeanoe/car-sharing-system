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

                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
                    while (dbread.Read()) {
                        User currUser = new User(Int32.Parse(dbread[0].ToString()), //accountID
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
                        users.Add(currUser);
                    }
                }
            }
            if (users.Count() == 0) {
                return null;
            } else {
                return users;
            }
        }

        // userQuerySingle return the first user found as an object.
        // return null if no user is found
        public static User userQuerySingle(String where)
        {
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
					return new User(Int32.Parse(dbread[0].ToString()), //accountID
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
					} else {
						return null;
					}
				}
			}
        }

        public void Registeration(User newUser) {
            String query = "INSERT TO User (email, password, permission, licenseNo, fName, lname, gender, birth, phone, street, suburb, postcode, territory, city, country, profileurl)";
            query += "VALUES (@email, @password, @permission, @license, @fName, @lName, @gender, @birth, @phoneNo, @street, @suburb, @postcode, @territory, @city, @country, @profileurl)";

            using (MySqlCommand mySqlCommand = new MySqlCommand(query)) {
                mySqlCommand.Parameters.AddWithValue("email", newUser.email);
                mySqlCommand.Parameters.AddWithValue("password", newUser.password);
                mySqlCommand.Parameters.AddWithValue("license", newUser.licenceNo);
                mySqlCommand.Parameters.AddWithValue("firstName", newUser.fname);
                mySqlCommand.Parameters.AddWithValue("lastName", newUser.lname);
                mySqlCommand.Parameters.AddWithValue("gender", newUser.gender);
                mySqlCommand.Parameters.AddWithValue("birth", newUser.birth);
                mySqlCommand.Parameters.AddWithValue("phoneNo", newUser.phone);
                mySqlCommand.Parameters.AddWithValue("street", newUser.street);
                mySqlCommand.Parameters.AddWithValue("suburb", newUser.suburb);
                mySqlCommand.Parameters.AddWithValue("postcode", newUser.postcode);
                mySqlCommand.Parameters.AddWithValue("territory", newUser.territory);
                mySqlCommand.Parameters.AddWithValue("city", newUser.city);
                mySqlCommand.Parameters.AddWithValue("country", newUser.country);
                mySqlCommand.Parameters.AddWithValue("profileurl", newUser.profileURL);
                mySqlCommand.ExecuteNonQuery();

            }
        }




        public static List<Car> carQuery(String where) {
			Debug.WriteLine("car query");
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
						Location newLocation = new Location(
							Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
							Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
						Car newCar = new Car(dbread[0].ToString() /*ID / license plate*/,
							newLocation, /* Car Location */
							dbread[4].ToString() /*Brand*/,
							dbread[5].ToString() /*Model*/,
							Convert.ToDouble(dbread[14].ToString()) /*Hourly rate*/);
						cars.Add(newCar);
						newCar.debug();
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
						Location newLocation = new Location(
							Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
							Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
						return new Car(dbread[0].ToString() /*ID / license plate*/,
							newLocation, /* Car Location */
							dbread[4].ToString() /*Brand*/,
							dbread[5].ToString() /*Model*/,
							Convert.ToDouble(dbread[14].ToString()) /*Hourly rate*/);
					} else {
						return null;
					}
				}
			}
		}

		public static Car carQuerySingleFull(String where) {
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
						Location newLocation = new Location(
							Convert.ToDecimal(dbread[1].ToString()) /*Latitude*/,
							Convert.ToDecimal(dbread[2].ToString()) /*Longitude*/);
						char transmission;
						if (dbread[9].ToString().Equals("Auto")) {
							transmission = 'A';
						} else {
							transmission = 'M';
						}
						Boolean cdPlayer = (Int32.Parse(dbread[16].ToString()) == 1) ? true : false;
						Boolean gps = (Int32.Parse(dbread[19].ToString()) == 1) ? true : false;
						Boolean bluetooth = (Int32.Parse(dbread[20].ToString()) == 1) ? true : false;
						//Boolean cruiseControl = (Int32.Parse(dbread[19].ToString()) == 1) ? true : false;
						//Boolean reverseCam = (Int32.Parse(dbread[20].ToString()) == 1) ? true : false;
						Boolean radio = (Int32.Parse(dbread[18].ToString()) == 1) ? true : false;
						Boolean airCon = (Int32.Parse(dbread[17].ToString()) == 1) ? true : false;
						return new Car(dbread[0].ToString() /*ID / license plate*/,
							newLocation, /* Car Location */
							dbread[3].ToString() /*Country*/,
							dbread[4].ToString() /*Brand*/,
							dbread[5].ToString() /*Model*/,
							dbread[6].ToString() /*Vehicle Type*/,
							Int32.Parse(dbread[7].ToString()) /*Seats*/,
							Int32.Parse(dbread[8].ToString()) /*Doors*/,
							transmission,
							dbread[10].ToString() /*Fuel Type*/,
							Int32.Parse(dbread[11].ToString()) /*Tank Size*/,
							Convert.ToDouble(dbread[12].ToString()) /*Fuel Consumption*/,
							Int32.Parse(dbread[13].ToString()) /*Average Range*/,
							Convert.ToDouble(dbread[14].ToString()) /*Hourly rate*/,
							cdPlayer,
							gps,
							bluetooth,
							/*cruiseControl,*/
							/*reverseCam,*/
							radio,
							airCon);
					} else {
						return null;
					}
				}
			}
		}
	}
}