using NUnit.Framework;
using car_sharing_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_sharing_system.Models.Tests
{
    [TestFixture()]
    public class UserModelTests 
    {
        [Test()]
        public void loginAttemptTestWithAdmin()
        {
            UserModel data = new UserModel();
            String password = "B59908A396DDEB8456000D031051DA8C786A5DD134901F6644E2727A63965086F904C2E15B7D4736ADF199EF07525D0841628F468518B8CEE565BAC68DCEE2BC";
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
            String password = "09E6DA93DF48FFF4A9E21C5788CD55862135BC0A4FD68907F0580320AB3083E8EBC8B8E1A923DCF9D1F910B2E9B208CB69C1C8C7C941E9F5B1CCD113FCC30553";
            String UserName = "rhoncus.Nullam@egestasSed.org";
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
        public void loginAttemptNoPassTest()
        {
            UserModel data = new UserModel();
            String password = "";
            String UserName = "rhoncus.Nullam@egestasSed.org";
            User myData = data.loginAttempt(UserName, password);
            if (myData != null)
            {
                Assert.Fail("No password check failure"); ;
            }
            else
            {
                Assert.Pass("No password check success");
            }
        }
        [Test()]
        public void loginAttemptNoUserTest()
        {
            UserModel data = new UserModel();
            String password = "09E6DA93DF48FFF4A9E21C5788CD55862135BC0A4FD68907F0580320AB3083E8EBC8B8E1A923DCF9D1F910B2E9B208CB69C1C8C7C941E9F5B1CCD113FCC30553";
            String UserName = "";
            User myData = data.loginAttempt(UserName, password);
            if (myData != null)
            {
                Assert.Fail("No user check failure"); ;
            }
            else
            {
                Assert.Pass("No user check success");
            }
        }
    }
}