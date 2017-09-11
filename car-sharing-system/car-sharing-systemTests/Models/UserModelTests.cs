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
            string beforeHash = "ZyiXDnElJ";
            string password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            string userName = "rhoncus.Nullam@egestasSed.org";
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

        public void registrationTest() // Test the registration function to see if it adds user to database with valid infomration
        {
            // Enter test code here (Placeholder)
            // newUser = DatabaseReader.userQueryInsert("accountID = '" + +"';");
            // Registration fields to be filled out are the following:
            // Username, Email, Password, License Number, First Name, Last Name, Gender
            // Date of Birth, Phone Number, Street Address, Suburb, Postcode, Territory
            // City, Country 
            // Assert.Fail("Test not completed yet");
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
        // This test is not implemented yet
        public void registerUserTest() // To register an user and add to database
        {
            DatabaseReader dr = new DatabaseReader();
            String beforeHash = "PasswordTest1"; // Plaintext Password
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512); // Hashing function for password
            string emailRego = "example@email.com"; // Valid email address
            string passwordRego = password; // Hashed Password
            string licenseRego = "123456789"; // 9 digit license number
            string firstRego = "John"; // First Name
            string lastNameRego = "Smith"; // Last Name
            string genderRego = "Male"; // Gender (Male / Female)
            string birthRego = "01/12/1990"; // Date of birth 'dd/mm/yyyy'
            string phoneNoRego = "9300 1212"; // Phone number
            string streetRego = "1 Example Street"; // Street Address
            string suburbRego = "Docklands"; // Suburb
            string postRego = "1234"; // Postcode
            string terrRego = "Territory"; // Territory
            string cityRego = "Melbourne"; // City
            string countryRego = "Australia"; // Country
            string urlRego = ""; // Avatar image url?
            newUser = new User(-1, emailRego, passwordRego, 0, licenseRego, firstRego, lastNameRego,
                genderRego, birthRego, phoneNoRego, streetRego, suburbRego, postRego, terrRego,
                cityRego, countryRego, urlRego);

            dr.Registeration(newUser);
        }
    }
}