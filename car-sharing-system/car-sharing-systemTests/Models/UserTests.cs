using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_sharing_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_sharing_system.Models.TestsRevised
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()] 
        public void hashMeTest() // Tests hashing function
        {
            // Arrange
            String Password = "Placeholder";
            // Act
            Password = new User().hashMe(Password);
            // Assert
            Assert.AreEqual(Password, "65950F6300E635CC97B92E515C1D17E5234072E9" +
                "15B0C98F75D8FE808F201FA815F2984460A4DCDB6A35D7776AACC317F1F47E" +
                "9FD6790D2CA07A5A9E9A793641");
        }
   
        [TestMethod()] 
        public void nullCheckerTestEmail() // Checks null for email address
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean a = new User(1, null, "", 0, "", "", "",
                       "", "", "", "", "", "", "",
                       "", "", "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestLicenseNo() // Checks null for license number 
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, null, "", "",
                       "", "", "", "", "", "", "",
                       "", "", "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestFirstName() // Checks null for first name 
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", null, "",
                       "", "", "", "", "", "", "", "", "", "")
                       .nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestLastName() // Checks null for last name 
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", null, 
                    "", "", "", "", "", "", "", "", "", "")
                    .nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestGender() // Checks null for gender 
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", "",
                       null, "", "", "", "", "", "", "", "", 
                       "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestDateOfBirth() // Checks null for date of birth 
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", "",
                       "", null, "", "", "", "", "", "", "", 
                       "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestPhoneNumber() // Checks null for phone number
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", "",
                       "", "", null, "", "", "", "", "", "",
                       "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestStreetAddress() // Checks null for street address
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", "",
                       "", "", "", null, "", "", "", "", "",
                       "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestSuburb() // Checks null for suburb
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", "",
                       "", "", "", "", null, "", "", "", "",
                       "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestPostcode() // Checks null for postcode
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", "",
                       "", "", "", "", "", null, "", "", "",
                       "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestTerritory() // Checks null for territory
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", "",
                       "", "", "", "", "", "", null, "", "",
                       "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestCity() // Checks null for city
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", "",
                       "", "", "", "", "", "", "", null, "",
                       "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void nullCheckerTestCountry() // Checks null for country
        {
            // Arrange 
            Boolean passTest = false;
            try
            {
                // Act
                Boolean b = new User(1, "", "", 0, "", "", "",
                       "", "", "", "", "", "", "", "", null,
                       "").nullChecker();
            }
            catch (Exception)
            {
                passTest = true;
            }
            // Assert
            Assert.AreEqual(passTest, true);
        }

        [TestMethod()]
        public void toStringTest() // Checks if User string output functrion works
        {
            // Arrange
            Boolean passTest = false;
            // Act
            String output = new User(1, "example@hotmail.com", "test123", 0, 
                "123456789", "John", "Smith", "Male", "06/07/1969",
                "0433 333 333", "5 Test Street", "Docklands", "3012", 
                "North", "Melbourne", "Australia",
                       "www.google.com").toString();
            // Assert
            if (output == null)
            {
                passTest = false;
            }
            else
            {
                passTest = true;
            }
            Assert.AreEqual(passTest,true);
        }
    }
}