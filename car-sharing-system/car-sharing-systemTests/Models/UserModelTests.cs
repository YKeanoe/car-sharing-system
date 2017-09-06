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
        [Test()]
        public void loginAttemptTestWithAdmin()
        {
            UserModel data = new UserModel();
            String beforeHash = "admin";
            String password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            String UserName = "admin@gmail.com";
            User myData = data.loginAttempt(UserName, password);
            if (myData != null)
            {
                Assert.Pass("Valid User in database");
            }
            else
            {
                Assert.Fail("Invalid user in database");
            }
        }
        [Test()]
        public void loginAttemptTestWithUser()
        {
            UserModel data = new UserModel();
            string beforeHash = "ZyiXDnElJ";
            string password = (beforeHash + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
            string userName = "rhoncus.Nullam@egestasSed.org";
            User myData = data.loginAttempt(userName, password);
            if (myData != null)
            {
                Assert.Pass("Valid User in database");
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
    }
}