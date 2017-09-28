using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using MySql.Data.MySqlClient;
using car_sharing_system.Models;
using System.Text;

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

		// UserCount returns the total number of available users
        public static int UserCount(String where)
        {
            String query;
            if (!String.IsNullOrEmpty(where))
            {
                query = "SELECT count(*) FROM User WHERE " + where;
            }
            else
            {
                query = "SELECT count(*) FROM User";
            }
            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader())
                {
                    if (dbread.Read())
                    {
                        return Int32.Parse(dbread[0].ToString());
                    }
                }
                return 0;
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
					} else {
						return null;
					}
				}
			}
        }

		// issueQuerySingle return the first issue found as an object.
        public static Issues issueQuerySingle(String where)
        {
            String query;
            if (!String.IsNullOrEmpty(where))
            {
                query = "SELECT * FROM Issues WHERE " + where;
            }
            else
            {
                query = "SELECT * FROM Issues";
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader())
                {
                    if (dbread.Read())
                    {
                        return new Issues(Int32.Parse(dbread[0].ToString()), //issueID
                                        Int32.Parse(dbread[1].ToString()),  //accountID
                                       Int32.Parse(dbread[2].ToString()), //bookingID
                                        DateTime.Parse(dbread[3].ToString()), //submissionDate
                                        dbread[4].ToString(), //subject
                                        dbread[5].ToString()); //description
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

		// Registeration function is used to register new user to the database.
        public void Registeration(User newUser)
        {
            String query = "INSERT INTO User (email, password, permission, licenseNo, firstName, lastName, gender, birth, phone, street, suburb, postcode, territory, city, country, profileurl) ";
            query += " VALUES (@email, @password, 0, @license, @fName, @lName, @gender, @birth, @phoneNo, @street, @suburb, @postcode, @territory, @city, @country, @profileurl);";
            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                Debug.WriteLine(newUser.toString());
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlCommand.Parameters.AddWithValue("@email", newUser.email);
                    mySqlCommand.Parameters.AddWithValue("@password", newUser.password);
                    mySqlCommand.Parameters.AddWithValue("@license", newUser.licenseNo);
                    mySqlCommand.Parameters.AddWithValue("@fName", newUser.fname);
                    mySqlCommand.Parameters.AddWithValue("@lName", newUser.lname);
                    mySqlCommand.Parameters.AddWithValue("@gender", newUser.gender);
                    mySqlCommand.Parameters.AddWithValue("@birth", newUser.birth);
                    mySqlCommand.Parameters.AddWithValue("@phoneNo", newUser.phone);
                    mySqlCommand.Parameters.AddWithValue("@street", newUser.street);
                    mySqlCommand.Parameters.AddWithValue("@suburb", newUser.suburb);
                    mySqlCommand.Parameters.AddWithValue("@postcode", newUser.postcode);
                    mySqlCommand.Parameters.AddWithValue("@territory", newUser.territory);
                    mySqlCommand.Parameters.AddWithValue("@city", newUser.city);
                    mySqlCommand.Parameters.AddWithValue("@country", newUser.country);
                    mySqlCommand.Parameters.AddWithValue("@profileurl", newUser.profileURL);

                    mySqlCommand.ExecuteNonQuery();
                }
                mySqlConnection.Close();
            }
        }
        public static void updateProfile(User newUser)
        {
            String query = "UPDATE User";
            query += " SET licenseNo = @license, firstName = @fName, lastName = @lName, gender = @gender,";
            query += " birth = @birth, phone = @phoneNo, street = @street, suburb = @suburb, postcode = @postcode,";
            query += " territory = @territory, city = @city, country = @country, profileurl = @profileurl ";
            query += " WHERE accountID = @accountID";
            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlCommand.Parameters.AddWithValue("@accountID", newUser.id);
                    mySqlCommand.Parameters.AddWithValue("@license", newUser.licenseNo);
                    mySqlCommand.Parameters.AddWithValue("@fName", newUser.fname);
                    mySqlCommand.Parameters.AddWithValue("@lName", newUser.lname);
                    mySqlCommand.Parameters.AddWithValue("@gender", newUser.gender);
                    mySqlCommand.Parameters.AddWithValue("@birth", newUser.birth);
                    mySqlCommand.Parameters.AddWithValue("@phoneNo", newUser.phone);
                    mySqlCommand.Parameters.AddWithValue("@street", newUser.street);
                    mySqlCommand.Parameters.AddWithValue("@suburb", newUser.suburb);
                    mySqlCommand.Parameters.AddWithValue("@postcode", newUser.postcode);
                    mySqlCommand.Parameters.AddWithValue("@territory", newUser.territory);
                    mySqlCommand.Parameters.AddWithValue("@city", newUser.city);
                    mySqlCommand.Parameters.AddWithValue("@country", newUser.country);
                    mySqlCommand.Parameters.AddWithValue("@profileurl", newUser.profileURL);

                    mySqlCommand.ExecuteNonQuery();
                }
                mySqlConnection.Close();
            }
        }
        // clientIssue function is used to add new issue to the database.
        public void clientIssue(Issues newIssue)
        {
            String query = "INSERT INTO Issues (accountID, bookingID,submissionDate, subject, description) ";
            query += " VALUES (@accountID, @bookingID, @submissionDate, @subject, @description) ";
            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString))
            {
                mySqlConnection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlCommand.Parameters.AddWithValue("@accountID", newIssue.accountID);
                    mySqlCommand.Parameters.AddWithValue("@bookingID", newIssue.bookingID);
                    mySqlCommand.Parameters.AddWithValue("@submissionDate", DateTime.Now);
                    mySqlCommand.Parameters.AddWithValue("@subject", newIssue.subject);
                    mySqlCommand.Parameters.AddWithValue("@description", newIssue.description);

                    mySqlCommand.ExecuteNonQuery();

                }
                mySqlConnection.Close();
            }
        }

		// carQuery returns a list of cars from the query.
        public static List<Car> carQuery(String where) {
			List<Car> cars = new List<Car>();
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
						//newCar.debug();
					}
				}
			}
			if (cars.Count() == 0) {
				Debug.WriteLine("query returns null");
				return null;
			} else {
				return cars;
			}
		}
		
		// carQuerySingle return the first car found as an object
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

		// carQuerySingleFull return the first car found as an object, filled
		// with all of the car's information.
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
												
						return new Car(dbread[0].ToString() /*ID / license plate*/,
							newLocation /* Car Location */,
							dbread[3].ToString() /*Country*/,
							dbread[4].ToString() /*Brand*/,
							dbread[5].ToString() /*Model*/,
							dbread[6].ToString() /*Vehicle Type*/,
							Int32.Parse(dbread[7].ToString()) /*Seats*/,
							Int32.Parse(dbread[8].ToString()) /*Doors*/,
							transmission,
							dbread[10].ToString() /*Fuel Type*/,
							Int32.Parse(dbread[11].ToString()) /*Tank Size*/,
							Convert.ToDouble(dbread[12]) /*Fuel Consumption*/,
							Int32.Parse(dbread[13].ToString()) /*Average Range*/,
							Convert.ToDouble(dbread[14]) /*Hourly rate*/,
							(Boolean)dbread[16] /*CD Player*/,
							(Boolean)dbread[18] /*GPS*/,
							(Boolean)dbread[19] /*Bluetooth*/,
							(Boolean)dbread[20] /*cruiseControl*/,
							(Boolean)dbread[21] /*reverseCam*/,
							(Boolean)dbread[17] /*Radio*/);
					} else {
						return null;
					}
				}
			}
		}

		// setCarBooked updates the car's status to B for Booked
		public static int setCarBooked(String id) {
			String query = "UPDATE Car SET status = 'B' WHERE numberPlate = '" + id + "'";
			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
				int numRowsUpdated = mySqlCommand.ExecuteNonQuery();
				Debug.WriteLine("rows affected = " + numRowsUpdated);
				return numRowsUpdated;
			}
		}

		// setCarUsed updates the car's status to U for being used
		public static int setCarUsed(String id) {
			String query = "UPDATE Car SET status = 'U' WHERE numberPlate = '" + id + "'";
			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
				int numRowsUpdated = mySqlCommand.ExecuteNonQuery();
				Debug.WriteLine("rows affected = " + numRowsUpdated);
				return numRowsUpdated;
			}
		}

		// enableCar updates the car's status to true
		public static int enableCar(String id) {
			String query = "UPDATE Car SET status = 'A' WHERE numberPlate = '" + id + "'";
			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
				int numRowsUpdated = mySqlCommand.ExecuteNonQuery();
				Debug.WriteLine("rows affected = " + numRowsUpdated);
				return numRowsUpdated;
			}
		}

		// bookingQuery returns the bookings found as a list of booking object.
		public static List<Booking> bookingQuery(String where) {
            List<Booking> myBooking = new List<Booking>();
			String query;
			if (!String.IsNullOrEmpty(where)) {
				query = "SELECT * FROM Booking WHERE " + where;
			} else {
				query = "SELECT * FROM Booking";
			}

			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
					while (dbread.Read()) {
						Debug.WriteLine(dbread[7].ToString());
						Debug.WriteLine(dbread[8].ToString());
						Location newLocation = new Location(
							Convert.ToDecimal(dbread[7].ToString()) /*Latitude*/,
							Convert.ToDecimal(dbread[8].ToString()) /*Longitude*/);
						String actEndDate = dbread[6].ToString();
						long endDate;
						if (!String.IsNullOrEmpty(actEndDate)) {
							endDate = Convert.ToInt64(DateTime.UtcNow.Subtract(DateTime.Parse(actEndDate)).TotalSeconds);
						} else {
							endDate = 0;
						}
						Booking currBook;
						DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
						// If endDate is not set, means the car 
						if (endDate == 0) {
							currBook = new Booking(
									Int32.Parse(dbread[0].ToString()), // BookingID
									Int32.Parse(dbread[1].ToString()), // AccountID
									dbread[2].ToString(), // Numberplate
									(long)DateTime.Parse(dbread[3].ToString()).Subtract(unixStart).TotalSeconds, // Booking date
									(long)DateTime.Parse(dbread[4].ToString()).Subtract(unixStart).TotalSeconds, // start date
									(long)DateTime.Parse(dbread[5].ToString()).Subtract(unixStart).TotalSeconds, // est end date
									newLocation // location from above
							);
						} else {
							currBook = new Booking(
									Int32.Parse(dbread[0].ToString()), // BookingID
									Int32.Parse(dbread[1].ToString()), // AccountID
									dbread[2].ToString(), // Numberplate
									(long)DateTime.Parse(dbread[3].ToString()).Subtract(unixStart).TotalSeconds, // Booking date
									(long)DateTime.Parse(dbread[4].ToString()).Subtract(unixStart).TotalSeconds, // start date
									(long)DateTime.Parse(dbread[5].ToString()).Subtract(unixStart).TotalSeconds, // est end date
									(long)DateTime.Parse(dbread[6].ToString()).Subtract(unixStart).TotalSeconds, // end date
									newLocation, // location from above
									Convert.ToDouble(dbread[7].ToString())
							);
						}
						currBook.debug();
                    }
                }
            }
            return myBooking;
        }
		
		// addBooking add a new booking to the database
		public static int addBooking(Booking book) {
			StringBuilder querysb = new StringBuilder();
			querysb.Append("INSERT INTO Booking(accountID,numberPlate,bookingDate,startDate,estimatedEndDate,endDate,bookinguserlocationLat,bookinguserlocationLong,travelDistance)");
			querysb.AppendFormat("VALUES ({0},'{1}', '{2}', '{3}', '{4}', null, {5}, {6}, null)",
								book.accountID,
								book.numberPlate,
								// Convert book unixtime to datetime
								new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.bookingDate)).ToString("yyyy-MM-dd HH:mm:ss"),
								new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.startDate)).ToString("yyyy-MM-dd HH:mm:ss"),
								new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(book.estEndDate)).ToString("yyyy-MM-dd HH:mm:ss"),
								book.latlong.lat, book.latlong.lng);
			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(querysb.ToString(), mySqlConnection);
				int numRowsUpdated = mySqlCommand.ExecuteNonQuery();
				Debug.WriteLine("rows affected = " + numRowsUpdated);
				return numRowsUpdated;
			}
		}

		// checkCarStatus is a debug function to check the car's status.
		public static void checkCarStatus(String id) {
			String query = "SELECT * FROM Car WHERE numberPlate = '" + id + "'";

			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

				using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
					if (dbread.Read()) {
						Debug.WriteLine("Car id " + id + " status is " + dbread[15].ToString());
					} else {
						Debug.WriteLine("Car id " + id + " isn't found");
					}
				}
			}
		}
		/*
		public static Booking checkUserBook(String userid) {
			String query = "SELECT * FROM Car WHERE numberPlate = '" + id + "'";

			using (MySqlConnection mySqlConnection = new MySqlConnection(sqlConnectionString)) {
				mySqlConnection.Open();
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

				using (MySqlDataReader dbread = mySqlCommand.ExecuteReader()) {
					if (dbread.Read()) {
						Debug.WriteLine("Car id " + id + " status is " + dbread[15].ToString());
					} else {
						return null;
					}
				}
			}
		}*/
	}
}