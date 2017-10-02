using NUnit.Framework;
using car_sharing_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Rework;


namespace car_sharing_system.Models.Tests
{
    [TestFixture()]
    public class UnitTests
    {
        protected Issues newIssue;

        protected User newUser;

        protected int bookingID = 1;

        //Function to get random number
        private static readonly Random getrandom = new Random();

        private static readonly object syncLock = new object();

        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        Random rnd = new Random(DateTime.Now.Millisecond);

        [Test()]
        public void loginAttemptTestWithAdmin() // Attempt login with admin credentials
        {
            UserModel data = new UserModel();

            // Plaintext password
            String beforeHash = "admin";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);

            // Admin email
            String UserName = "admin@gmail.com";
            User myData = data.loginAttempt(UserName, password);

            // If database returns data from a matching entry
            if (myData != null)
            {
                Assert.Pass("Valid User in database with matching email: " + myData.email);
            }

            // If database does not find a matching entry
            else
            {
                Assert.Fail("Invalid user in database, invalid email: " + myData.email + password);
            }
        }

        [Test()]
        public void loginAttemptTestWithUser() // Attempt login with user credentials
        {
            UserModel data = new UserModel();
            String beforeHash = "soNzIMHTX";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String userName = "Nulla@elitpharetra.ca";
            User myData = data.loginAttempt(userName, password);
            if (myData != null)
            {
                Assert.Pass("Valid User in database, email: " + myData.email);
            }
            else
            {
                Assert.Fail("Invalid user in database");
            }
        }

        [Test()]
        public void loginAttemptNoPassTest() // Attempt login with no password entered
        {
            UserModel data = new UserModel();
            String beforeHash = "";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String userName = "Nulla@elitpharetra.ca";
            User myData = data.loginAttempt(userName, password);
            if (myData != null)
            {
                Assert.Fail("No password check failure"); ;
            }
            else
            {
                Assert.Pass("Login fail");
            }
        }

        [Test()]
        public void loginAttemptNoUserTest() // Attempt login with no username entered
        {
            UserModel data = new UserModel();
            String beforeHash = "soNzIMHTX";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String userName = "";
            User myData = data.loginAttempt(userName, password);
            if (myData != null)
            {
                Assert.Fail("No user check failure"); ;
            }
            else
            {
                Assert.Pass("Login fail");
            }
        }

        [Test()]
        public void loginAttemptNoCredentials() // Attempt to login with no login entered
        {
            UserModel data = new UserModel();
            String beforeHash = "";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String userName = "";
            User myData = data.loginAttempt(userName, password);
            if (myData != null)
            {
                Assert.Fail("No Credentials check failure");
            }
            else
            {
                Assert.Pass("No match found in database");
            }
        }

        [Test()]
        public void loginAttemptInvalidUsername() // Attempt to login with invalid username
        {
            UserModel data = new UserModel();
            String beforeHash = "test321";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String userName = "NotAnRegisteredUser@example.com";
            User myData = data.loginAttempt(userName, password);
            if (myData != null)
            {
                Assert.Fail("No Credentials check failure");
            }
            else
            {
                Assert.Pass("No match found in database");
            }
        }

        [Test()]
        public void loginAttemptInvalidPassword() // Attempt to login with invalid password
        {
            UserModel data = new UserModel();
            String beforeHash = "321test";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String userName = "NotAnRegisteredUser@example.com";
            User myData = data.loginAttempt(userName, password);
            if (myData != null)
            {
                Assert.Fail("No Credentials check failure");
            }
            else
            {
                Assert.Pass("No match found in database");
            }
        }

        [Test()]
        public void loginAttemptNull() // Attempt to login with null data
        {
            UserModel data = new UserModel();
            String beforeHash = null;
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String userName = null;
            User myData = data.loginAttempt(userName, password);
            if (myData != null)
            {
                Assert.Fail("No Credentials check failure");
            }
            else
            {
                Assert.Pass("No match found in database");
            }
        }

        [Test()]
        public void HashFunctionTest() // Checks to see if hashing function is working properly
        {
            // Plaintext password
            String beforeHash = "ZyiXDnElJ";

            // Hashes plaintext password with salt 'CarSharing2017' and SHA512 hash function.
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);

            // Expected Hash Result
            if (password == "09E6DA93DF48FFF4A9E21C5788CD55862135BC0A4FD68907F0580320AB3083E8EBC8B8E1A923DCF9D1F910B2E9B208CB69C1C8C7C941E9F5B1CCD113FCC30553")
            {
                Assert.Pass("Password hash match");
            }

            // If Hash result does not match
            else
            {
                Assert.Fail("Password hash mismatch, hashed value: " + password);
            }
        }

        [Test()]
        public void loginAttemptWithHash() // This test should result with password mismatch
        {
            // Plaintext password
            String beforeHash = "09E6DA93DF48FFF4A9E21C5788CD55862135BC0A4FD68907F0580320AB3083E8EBC8B8E1A923DCF9D1F910B2E9B208CB69C1C8C7C941E9F5B1CCD113FCC30553";

            // Hashes plaintext password with salt 'CarSharing2017' and SHA512 hash function.
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);

            // Expected Hash Result
            if (password == "09E6DA93DF48FFF4A9E21C5788CD55862135BC0A4FD68907F0580320AB3083E8EBC8B8E1A923DCF9D1F910B2E9B208CB69C1C8C7C941E9F5B1CCD113FCC30553")
            {
                Assert.Fail("Password match");
            }

            // If Hash result does not match
            else
            {
                Assert.Pass("Password mismatch, hashed value: " + password);
            }
        }

        [Test()]
        public void registerUserTestValidDetails() // To register an user and add to database with valid details
        {
            string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
            string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = "example3@email.com" + randInt; // Valid email
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = randLicense; // 9 digit license number
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
            String phone = "9300 1212"; // Phone number
            String street = "1 Example Street"; // Street Address
            String suburb = "Docklands"; // Suburb
            String postcode = "1234"; // Postcode
            String territory = "Territory"; // Territory
            String city = "Melbourne"; // City
            String country = "Australia"; // Country
            String profileURL = "null"; // Avatar image url?
            newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                gender, birth, phone, street, suburb, postcode, territory,
                city, country, profileURL);
            dr.Registeration(newUser); // Register new user

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenseNo
                            + "\nFirst Name: " + myData.fname
                            + "\nLast Name: " + myData.lname
                            + "\nGender: " + myData.gender
                            + "\nDate of Birth: " + myData.birth
                            + "\nPhone Number: " + myData.phone
                            + "\nStreet Address: " + myData.street
                            + "\nSuburb: " + myData.suburb
                            + "\nPostcode: " + myData.postcode
                            + "\nTerritory: " + myData.territory
                            + "\nCity: " + myData.city
                            + "\nCountry: " + myData.country
                            + "\nImage URL: " + myData.profileURL);
            }
            else
            {
                Assert.Fail("Email and/or Password does not match in database.");
            }
        }

        [Test()]
        public void registerUserTestNopassword() // To attempt to register a user with no password
        {
            string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
            string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
            DatabaseReader dr = new DatabaseReader();
            String password = null; // No password
            String email = "example3@email.com" + randInt; // Valid email 
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = randLicense; // 9 digit license number
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
            String phone = "9300 1212"; // Phone number
            String street = "1 Example Street"; // Street Address
            String suburb = "Docklands"; // Suburb
            String postcode = "1234"; // Postcode
            String territory = "Territory"; // Territory
            String city = "Melbourne"; // City
            String country = "Australia"; // Country
            String profileURL = "null"; // Avatar image url?
            newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                gender, birth, phone, street, suburb, postcode, territory,
                city, country, profileURL);
            dr.Registeration(newUser); // Register new user

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, password);
            if (myData != null)
            {
                Assert.Fail("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenseNo
                            + "\nFirst Name: " + myData.fname
                            + "\nLast Name: " + myData.lname
                            + "\nGender: " + myData.gender
                            + "\nDate of Birth: " + myData.birth
                            + "\nPhone Number: " + myData.phone
                            + "\nStreet Address: " + myData.street
                            + "\nSuburb: " + myData.suburb
                            + "\nPostcode: " + myData.postcode
                            + "\nTerritory: " + myData.territory
                            + "\nCity: " + myData.city
                            + "\nCountry: " + myData.country
                            + "\nImage URL: " + myData.profileURL);
            }
            else
            {
                Assert.Pass("Email and/or Password does not match in database.");
            }
        }

        [Test()]
        public void registerUserTestDuplicateEmail() // To register an user and attempt to add duplicate email to database
        {
            String test = "";
            try
            {
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com"; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("Duplicate for email was handled successfully.");
            }
            else
            {
                Assert.Fail("Duplicate for email was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoEmail() // To register an user and add to database with no email
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = null; // No email entered
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for email was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for email was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestDuplicateLicense() // To register an user and add to database with duplicate license
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString();
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = "123456789"; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("Duplicate for licenseNo was handled successfully.");
            }
            else
            {
                Assert.Fail("Duplicate for licenseNo was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNolicenseNo() // To register an user and add to database with no license number entered
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString();
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = null; // 9 digit license number, nothing entered
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for licenseNo was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for licenseNo was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNolicenseNoTerritory() // To register an user and add to database with no license number or territory entered
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString();
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = null; // 9 digit license number, nothing entered
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = null; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for licenseNo and territory was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for licenseNo and territory was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNolicenseNoFirstName() // To register an user and add to database with no license number or first name entered
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString();
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = null; // 9 digit license number, nothing entered
                String fname = null; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for licenseNo and first name was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for licenseNo and first name was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoPostcodeFirstName() // To register an user and add to database with no post code or first name entered
        {
            String test = "";
            try
            {
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                string randInt = GetRandomNumber(0, 1000).ToString();
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number, nothing entered
                String fname = null; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "null"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for postcode and first name was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for postcode and first name was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoFirstName() // To register an user and add to database with no first name
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = null; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for first name was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for first name was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoSuburbLastName() // To register an user and add to database with no suburb or last name
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = null; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = null; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for suburb and last name was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for suburb and last name was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoLastName() // To register an user and add to database with no last name
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = null; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for last name was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for last name was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoLastNameFirstName() // To register an user and add to database with no last name or first name
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = null; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for first name and last name was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for first name and last name was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoGenderProfileURL() // To register an user and add to database with no gender or profileURL
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = null; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = null; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for gender and profileURL was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for gender and profileURL was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoprofileURLPhoneNumber() // To register an user and add to database with profileURL or phone number
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = null; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for profileURL and phone number was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for profileURL and phone number was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoCountryGender() // To register an user and add to database with no country or gender
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = null; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "12345678"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = null; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for country and gender was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for country and gender was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoGender() // To register an user and add to database with no gender
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = null; // Gender (Male / Female)
                String birth = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for gender was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for gender was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoGenderDateofBirth() // To register an user and add to database with no gender or date of birth
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = null; // Gender (Male / Female)
                String birth = null; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for gender and date of birth was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for gender and date of birth was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoGenderFirstName() // To register an user and add to database with no gender or first name
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = null; // First Name
                String lname = "Smith"; // Last Name
                String gender = null; // Gender (Male / Female)
                String birth = "26/02/1997"; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for gender and first name was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for gender and first name was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoDateOfBirth() // To register an user and add to database with no date of birth
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = null; // Date of birth 'dd/mm/yyyy'
                String phone = "9300 1212"; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for date of birth was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for date of birth was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoDateOfBirthPhoneNumber() // To register an user and add to database with no date of birth or phone number
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = null; // Date of birth 'dd/mm/yyyy'
                String phone = null; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for date of birth and phone number was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for date of birth and phone number was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoPhoneNumber() // To register an user and add to database with no phone number
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = null; // Phone number
                String street = "1 Example Street"; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for phone number was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for phone number was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoPhoneNumberStreet() // To register an user and add to database with no phone number and street address
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = null; // Phone number
                String street = null; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for phone number and street address was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for phone number and street address was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoStreetAddress() // To register an user and add to database with no street address
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = null; // Street Address
                String suburb = "Docklands"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for street address was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for street address was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoStreetAddressSuburb() // To register an user and add to database with no street address and suburb
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = null; // Street Address
                String suburb = null; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for street address and suburb was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for street address and suburb was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoSuburb() // To register an user and add to database with no suburb
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = "1 example street"; // Street Address
                String suburb = null; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for suburb was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for suburb was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoSuburbPostcode() // To register an user and add to database with no suburb and postcode
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = "1 example street"; // Street Address
                String suburb = null; // Suburb
                String postcode = null; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for suburb and postcode was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for suburb and postcode was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoPostcode() // To register an user and add to database with no postcode
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = "1 example street"; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = null; // Postcode
                String territory = "Territory"; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new 
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for postcode was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for postcode was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoPostcodeTerritory() // To register an user and add to database with no postcode or territory
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = "1 example street"; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = null; // Postcode
                String territory = null; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new 
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for postcode and territory was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for postcode and territory was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoTerritory() // To register an user and add to database with no territory
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = "1 example street"; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = null; // Territory
                String city = "Melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for territory was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for territory was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoCity() // To register an user and add to database with no city
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = "1 example street"; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "territory1"; // Territory
                String city = null; // City
                String country = "Australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user

                UserModel data = new UserModel();
                User myData = data.loginAttempt(email, passwordTest);
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for city was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for city was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoCityCountry() // To register an user and add to database with no city or country
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = "1 example street"; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "territory1"; // Territory
                String city = null; // City
                String country = null; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user

                UserModel data = new UserModel();
                User myData = data.loginAttempt(email, passwordTest);
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for city and country was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for city and country was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoPostcodeTerritoryFirstName() // To register an user and add to database with no postcode, territory or first name
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = null; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = "1 Test Street"; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = null; // Postcode
                String territory = null; // Territory
                String city = "melbourne"; // City
                String country = "australia"; // Country
                String profileURL = "www.test.com.au"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for postcode, territory and first name was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for postcode, territory and first name was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoStreetFirstName() // To register an user and add to database with no street address or first name
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = null; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = null; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "territory1"; // Territory
                String city = "melbourne"; // City
                String country = "australia"; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for street and first name was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for street and first name was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoFirstLastGender() // To register an user and add to database with no first name, last name and gender
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = null; // First Name
                String lname = null; // Last Name
                String gender = null; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "123456789"; // Phone number
                String street = "1 example street"; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "territory1"; // Territory
                String city = "melbourne"; // City
                String country = "Australia"; // Country
                String profileURL = "www.imgur.com"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for first name, last name and gender was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for first name, last name and gender was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestSuburbPostcodeTerritory() // To register an user and add to database with no suburb, postcode and territory
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "123456789"; // Phone number
                String street = "1 Example street"; // Street Address
                String suburb = null; // Suburb
                String postcode = null; // Postcode
                String territory = null; // Territory
                String city = "melbourne"; // City
                String country = "australia"; // Country
                String profileURL = "www.test.com"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for suburb, postcode and territory was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for suburb, postcode and territory was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoCountryPhoneStreet() // To register an user and add to database with no country, phone and street
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = null; // Phone number
                String street = null; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "territory1"; // Territory
                String city = "melbourne"; // City
                String country = null; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for country, phone and street was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for country, phone and street was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoCountry() // To register an user and add to database with no country
        {
            String test = "";
            try
            {
                string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
                string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
                DatabaseReader dr = new DatabaseReader();
                String password = "Testing1"; // Plaintext Password
                String email = "example3@email.com" + randInt; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = randLicense; // 9 digit license number
                String fname = "John"; // First Name
                String lname = "Smith"; // Last Name
                String gender = "Male"; // Gender (Male / Female)
                String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
                String phone = "0482999231"; // Phone number
                String street = "1 example street"; // Street Address
                String suburb = "Essendon"; // Suburb
                String postcode = "1234"; // Postcode
                String territory = "territory1"; // Territory
                String city = "melbourne"; // City
                String country = null; // Country
                String profileURL = "null"; // Avatar image url?
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for country was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for country was not handled successfully.");
            }
        }

        [Test()]
        public void registerUserTestNoProfileURL() // To register an user and add to database with no profile url
        {
            string randInt = GetRandomNumber(0, 1000).ToString(); // Randomly generated number
            string randLicense = GetRandomNumber(100000000, 999999999).ToString(); // Randomly generated license number
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = "example3@email.com" + randInt; // Valid email
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = randLicense; // 9 digit license number
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
            String phone = "0482999231"; // Phone number
            String street = "1 example street"; // Street Address
            String suburb = "Essendon"; // Suburb
            String postcode = "1234"; // Postcode
            String territory = "territory1"; // Territory
            String city = "melbourne"; // City
            String country = "Australia"; // Country
            String profileURL = ""; // Avatar image url?
            newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                gender, birth, phone, street, suburb, postcode, territory,
                city, country, profileURL);
            dr.Registeration(newUser); // Register new user

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenseNo
                            + "\nFirst Name: " + myData.fname
                            + "\nLast Name: " + myData.lname
                            + "\nGender: " + myData.gender
                            + "\nDate of Birth: " + myData.birth
                            + "\nPhone Number: " + myData.phone
                            + "\nStreet Address: " + myData.street
                            + "\nSuburb: " + myData.suburb
                            + "\nPostcode: " + myData.postcode
                            + "\nTerritory: " + myData.territory
                            + "\nCity: " + myData.city
                            + "\nCountry: " + myData.country
                            + "\nImage URL: " + myData.profileURL);
            }
            else
            {
                Assert.Fail("Email and/or Password does not match in database.");
            }
        }

        [Test()]
        public void registerUserTestNoDetails() // To register an user and add to database with no registration info entered
        {
            String test = "";
            try
            {
                DatabaseReader dr = new DatabaseReader();
                String password = null; // Plaintext Password
                String email = null; // Valid email
                String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
                String licenseNo = null; // 9 digit license number
                String fname = null; // First Name
                String lname = null; // Last Name
                String gender = null; // Gender (Male / Female)
                String birth = null; // Date of birth 'dd/mm/yyyy'
                String phone = null; // Phone number
                String street = null; // Street Address
                String suburb = null; // Suburb
                String postcode = null; // Postcode
                String territory = null; // Territory
                String city = null; // City
                String country = null; // Country
                String profileURL = null; // Avatar Image Url
                newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                    gender, birth, phone, street, suburb, postcode, territory,
                    city, country, profileURL);
                dr.Registeration(newUser); // Register new user
            }
            catch (Exception)
            {
                test = "Pass";
            }
            if (test == "Pass")
            {
                Assert.Pass("NULL for registration was handled successfully.");
            }
            else
            {
                Assert.Fail("Null for registration was not handled successfully.");
            }
        }

        //[Test()]
        public void issuesTestValidDetails() // Submit issue with valid details
        {
            String subjectIssueText = "Test";
            String descriptionText = "The quick brown fox jumps over the fence";
            DatabaseReader dr = new DatabaseReader();
            newIssue = new Issues(-1, -1, bookingID, DateTime.Now, subjectIssueText, descriptionText);

            dr.clientIssue(newIssue); ; // May not appear to submit the issue yet,

            IssueModel issue = new IssueModel();
            Issues myIssue = issue.issueAttempt(subjectIssueText, descriptionText);
            if (myIssue != null)
            {
                Assert.Pass("Issue Submitted");
            }
            else
            {
                Assert.Fail("Issue not submitted");
            }
        }

        //[Test()]
        public void issuesTestNoSubject() // Submit issue with no subject
        {
            String subjectIssueText = "";
            String descriptionText = "The quick brown fox jumps over the fence";
            DatabaseReader dr = new DatabaseReader();
            newIssue = new Issues(-1, -1, bookingID, DateTime.Now, subjectIssueText, descriptionText);

            dr.clientIssue(newIssue); // May not appear to submit the issue yet

            IssueModel issue = new IssueModel();
            Issues myIssue = issue.issueAttempt(subjectIssueText, descriptionText);
            if (myIssue != null)
            {
                Assert.Fail("Issue Submitted");
            }
            else
            {
                Assert.Pass("Issue not submitted");
            }
        }

        //[Test()]
        public void issuesTestNoDescription() // Submit issue with no description
        {
            String subjectIssueText = "Test";
            String descriptionText = "";
            DatabaseReader dr = new DatabaseReader();
            newIssue = new Issues(-1, -1, bookingID, DateTime.Now, subjectIssueText, descriptionText);

            dr.clientIssue(newIssue); // May not appear to submit the issue yet

            IssueModel issue = new IssueModel();
            Issues myIssue = issue.issueAttempt(subjectIssueText, descriptionText);
            if (myIssue != null)
            {
                Assert.Fail("Issue Submitted");
            }
            else
            {
                Assert.Pass("Issue not submitted");
            }
        }

        //[Test()]
        public void issuesTestNoSubjectOrDescription() // Submit issue with no subject or description
        {
            String subjectIssueText = "";
            String descriptionText = "";
            DatabaseReader dr = new DatabaseReader();
            newIssue = new Issues(-1, -1, bookingID, DateTime.Now, subjectIssueText, descriptionText);

            dr.clientIssue(newIssue); // May not appear to submit the issue yet

            IssueModel issue = new IssueModel();
            Issues myIssue = issue.issueAttempt(subjectIssueText, descriptionText);
            if (myIssue != null)
            {
                Assert.Fail("Issue Submitted");
            }
            else
            {
                Assert.Pass("Issue not submitted");
            }
        // TODO: Create unit tests for singleQueries and ListQueries for databaseReader.
        // - carQuery(
        // - bookingQuery(
        // - userQuery(
        //
        }
        protected Car carList;
        protected List<Car> cars = new List<Car>();
        [Test()]
        public void carQuery() // Checks to see if it can find a matching car in the database with the query information.
        {
            String test = "Pass";
            try
            {
                String numberPlate = "8W69B0";
                DatabaseReader dr = new DatabaseReader();
                String query = "status = 'A' AND numberPlate = '" + numberPlate + "'";
                carList = DatabaseReader.carQuerySingleFull(query);
            }
            catch (Exception)
            {
                test = "Fail";
            }
            if (test == "Pass")
            {
                Assert.Pass("Valid Car in database. " + "Car info: \n"
                            + "\nLicense Plate: " + carList.numberPlate
                            + "\nLocation: " + carList.latlong
                            + "\nCountry: " + carList.country
                            + "\nBrand: " + carList.brand
                            + "\nModel: " + carList.model
                            + "\nVehicle Type: " + carList.vehicleType
                            + "\nSeats: " + carList.seats
                            + "\nDoors: " + carList.doors
                            + "\nTransmission: " + carList.transmission
                            + "\nFuel Type: " + carList.fuelType
                            + "\nTank Size: " + carList.tankSize
                            + "\nFuel Consumption: " + carList.fuelConsumption
                            + "\nAverage Range: " + carList.avgRange
                            + "\nHourly Rate: " + carList.rate
                            + "\nCD Player: " + carList.cdPlayer
                            + "\nGPS: " + carList.gps
                            + "\nBluetooth: " + carList.bluetooth
                            + "\nCruise Control: " + carList.cruiseControl
                            + "\nReverse Camera: " + carList.reverseCam
                            + "\nRadio: " + carList.radio);
            }
            else
            {
                Assert.Fail("Car was not found from car query.");
            }
        }
        protected User userListing;
        protected List<User> users = new List<User>();
        [Test()]
        public void userQuery() // Checks to see if it can find a matching user in the database with the query information.
        {
            String test = "Pass";
            try
            {
                userListing = DatabaseReader.userQuerySingle("accountID = '" + 100 + "';");
            }
            catch (Exception)
            {
                test = "Fail";
            }
            if (test == "Pass")
            {
                Assert.Pass("Valid User found in database. " + "User info: \n"
                            + "\nEmail Address: " + userListing.email
                            + "\nPassword: " + userListing.password
                            + "\nPermission: " + userListing.permission
                            + "\nLicense Number: " + userListing.licenseNo
                            + "\nFirst Name: " + userListing.fname
                            + "\nLast Name: " + userListing.lname
                            + "\nGender: " + userListing.gender
                            + "\nDate of Birth: " + userListing.birth
                            + "\nPhone Number: " + userListing.phone
                            + "\nStreet Address: " + userListing.street
                            + "\nSuburb: " + userListing.suburb
                            + "\nPostcode: " + userListing.postcode
                            + "\nTerritory: " + userListing.territory
                            + "\nCountry: " + userListing.country
                            + "\nProfile URL: " + userListing.profileURL);
            }
            else
            {
                Assert.Fail("User was not found in database.");
            }
        }
    }
}