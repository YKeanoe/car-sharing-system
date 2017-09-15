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
    public class UserModelTests
    {
        protected Issues newIssue;
        protected User newUser;
        [Test()]
        // Attempt login with admin credentials.
        public void loginAttemptTestWithAdmin()
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
                Assert.Fail("Invalid user in database, invalid email: " + myData.email);
            }
        }

        [Test()]
        // Attempt login with user credentials
        public void loginAttemptTestWithUser()
        {
            UserModel data = new UserModel();
            String beforeHash = "ZyiXDnElJ";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String userName = "rhoncus.Nullam@egestasSed.org";
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
        public void loginAttemptNoPassTest()
        {
            UserModel data = new UserModel();
            String beforeHash = "";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String userName = "rhoncus.Nullam@egestasSed.org";
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
        public void loginAttemptNoUserTest()
        {
            UserModel data = new UserModel();
            String beforeHash = "ZyiXDnElJ";
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
        public void loginAttemptNoCredentials()
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
        public void loginAttemptNull()
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
        public void HashFunctionTest() // 
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
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1" ; // Plaintext Password
            String email = "example3@email.com"; // Valid email 
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456723"; // 9 digit license number
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNopassword() // To attempt to register a user with no password
        {
            DatabaseReader dr = new DatabaseReader();
            String password = ""; // No password
            String email = "example3@email.com"; // Valid email 
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456723"; // 9 digit license number
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoEmail() // To register an user and add to database with no email
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456723"; // 9 digit license number
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNolicenseNo() // To register an user and add to database with no license number entered
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = ""; // 9 digit license number, nothing entered
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoFirstName() // To register an user and add to database with no first name
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = ""; // First Name
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoLastName() // To register an user and add to database with no last name
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = "John"; // First Name
            String lname = ""; // Last Name
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoGender() // To register an user and add to database with no gender
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = ""; // Gender (Male / Female)
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoDateOfBirth() // To register an user and add to database with no date of birth
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = ""; // Date of birth 'dd/mm/yyyy'
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoPhoneNumber() // To register an user and add to database with no phone number
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
            String phone = ""; // Phone number
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoStreetAddress() // To register an user and add to database with no street address
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
            String phone = "0482999231"; // Phone number
            String street = ""; // Street Address
            String suburb = "Docklands"; // Suburb
            String postcode = "1234"; // Postcode
            String territory = "Territory"; // Territory
            String city = "Melbourne"; // City
            String country = "Australia"; // Country
            String profileURL = "null"; // Avatar image url?
            newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                gender, birth, phone, street, suburb, postcode, territory,
                city, country, profileURL);
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoSuburb() // To register an user and add to database with no suburb
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
            String phone = "0482999231"; // Phone number
            String street = "1 example street"; // Street Address
            String suburb = ""; // Suburb
            String postcode = "1234"; // Postcode
            String territory = "Territory"; // Territory
            String city = "Melbourne"; // City
            String country = "Australia"; // Country
            String profileURL = "null"; // Avatar image url?
            newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                gender, birth, phone, street, suburb, postcode, territory,
                city, country, profileURL);
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoPostcode() // To register an user and add to database with no postcode
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
            String phone = "0482999231"; // Phone number
            String street = "1 example street"; // Street Address
            String suburb = "Essendon"; // Suburb
            String postcode = ""; // Postcode
            String territory = "Territory"; // Territory
            String city = "Melbourne"; // City
            String country = "Australia"; // Country
            String profileURL = "null"; // Avatar image url?
            newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                gender, birth, phone, street, suburb, postcode, territory,
                city, country, profileURL);
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoTerritory() // To register an user and add to database with no territory
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
            String phone = "0482999231"; // Phone number
            String street = "1 example street"; // Street Address
            String suburb = "Essendon"; // Suburb
            String postcode = "1234"; // Postcode
            String territory = ""; // Territory
            String city = "Melbourne"; // City
            String country = "Australia"; // Country
            String profileURL = "null"; // Avatar image url?
            newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                gender, birth, phone, street, suburb, postcode, territory,
                city, country, profileURL);
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoCity() // To register an user and add to database with no city
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
            String fname = "John"; // First Name
            String lname = "Smith"; // Last Name
            String gender = "Male"; // Gender (Male / Female)
            String birth = "12/02/1980"; // Date of birth 'dd/mm/yyyy'
            String phone = "0482999231"; // Phone number
            String street = "1 example street"; // Street Address
            String suburb = "Essendon"; // Suburb
            String postcode = "1234"; // Postcode
            String territory = "territory1"; // Territory
            String city = ""; // City
            String country = "Australia"; // Country
            String profileURL = "null"; // Avatar image url?
            newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                gender, birth, phone, street, suburb, postcode, territory,
                city, country, profileURL);
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoCountry() // To register an user and add to database with no country
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
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
            String country = ""; // Country
            String profileURL = "null"; // Avatar image url?
            newUser = new User(-1, email, password, 0, licenseNo, fname, lname,
                gender, birth, phone, street, suburb, postcode, territory,
                city, country, profileURL);
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void registerUserTestNoProfileURL() // To register an user and add to database with no profile url
        {
            DatabaseReader dr = new DatabaseReader();
            String password = "Testing1"; // Plaintext Password
            String email = ""; // No email entered
            String passwordTest = (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            String licenseNo = "123456789"; // 9 digit license number, nothing entered
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
            // dr.Registeration(newUser); This line is commented out because test can only be run once to register user as you can't
            // register the same user two times with the same email or license number.

            UserModel data = new UserModel();
            User myData = data.loginAttempt(email, passwordTest);
            if (myData != null)
            {
                Assert.Pass("Valid User in database" + "user info: \n"
                            + "\nID: " + myData.id
                            + "\nEmail: " + myData.email
                            + "\nPassword: " + myData.password
                            + "\nPermission: " + myData.permission
                            + "\nLicense Number: " + myData.licenceNo
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

        //[Test()]
        public void issuesTest() // Test issue submission, may not be working yet
        {
            String subjectIssueText = "Test";
            String descriptionText = "The quick brown fox jumps over the fence";
            DatabaseReader dr = new DatabaseReader();
            newIssue = new Issues(-1, -1, -1, -1, subjectIssueText, descriptionText);

            dr.Issue(newIssue); // May not appear to submit the issue yet,

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
    }
}