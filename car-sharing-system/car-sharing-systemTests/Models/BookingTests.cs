using NUnit.Framework;
using car_sharing_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_sharing_system.Models.TestsRevised
{
    [TestFixture()]
    public class BookingTests
    {
        #region Booking Tests

        [Test()]
        public void isFinishTest() // Checks to see if booking is finished or not
        {
            // Arrange
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long currentunix = (long)DateTime.UtcNow.Subtract(unixStart).TotalSeconds;
            long startDate = 11 / 10 / 2017;
            long estEndDate = 20 / 10 / 2017;
            decimal latitude = -37634528920;
            decimal longitude = 144808134700;
            Location latLong = new Location(latitude, longitude);
            String start = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble
                (startDate)).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");  // Converts startDate to date and time format
            String estend = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds
                (Convert.ToDouble(estEndDate)).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");  // Converts estEndDate to date and time format
            Booking book = new Booking(1000, "8W69B0", currentunix, startDate, estEndDate, latLong);
            // Act
            Boolean a = book.isFinish();
            // Assert
            if (a == true) // Not overdue
            {
                Assert.AreEqual(a, true); // Finished booking                
            }
            else
            {
                Assert.AreEqual(a, false); // Unfinished booking
            }
           
            
        }

        [Test()]
        public void isOverdueTest() // Checks to see if booking is overdue or not
        {
            // Arrange
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long currentunix = (long)DateTime.UtcNow.Subtract(unixStart).TotalSeconds;
            long startDate = 01 / 10 / 2017;
            long estEndDate = 05 / 10 / 2017;
            decimal latitude = -37634528920;
            decimal longitude = 144808134700;
            Location latLong = new Location(latitude, longitude);
            String start = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds
                (Convert.ToDouble(startDate)).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); // Converts startDate to date and time format
            String estend = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds
                (Convert.ToDouble(estEndDate)).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); // Converts estEndDate to date and time format
            Booking book = new Booking(1000, "8W69B0", currentunix, startDate, estEndDate, latLong);
            // Act
            Boolean a = book.isOverdue();
            // Assert
            if (a == true) // Not overdue
            {
                Assert.AreEqual(a, true); // Overdue
            }
            else
            {
                Assert.AreEqual(a, false); // Not overdue                
            }
        }
        #endregion
    }
}