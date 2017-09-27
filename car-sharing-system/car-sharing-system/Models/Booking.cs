using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace car_sharing_system.Models
{
    public class Booking
    {
        public int bookingID { get; }
        public int accountID { get;}
        public String numberPlate { get; }
		public long bookingDate { get; set; }
		public long startDate { get; set; }
		public long estEndDate { get; set; }
		public long endDate { get; set; }
		public Location latlong { get; set; }
        public Double travelDistance { get; }

		// Used to add new booking
        public Booking(int accountID, String numberPlate, long startDate, long estEndDate, Location latlong) {
            this.accountID = accountID;
            this.numberPlate = numberPlate;
            this.startDate = startDate;
            this.estEndDate = estEndDate;
            this.latlong = latlong;
        }

		// Used to get full new booking
		public Booking(int bookingID, int accountID, String numberPlate, long bookingDate, long startDate,
					long estEndDate, long endDate, Location latlong, Double travelDistance)
        {
            this.bookingID = bookingID;
            this.accountID = accountID;
            this.numberPlate = numberPlate;
			this.bookingDate = bookingDate;
            this.startDate = startDate;
			this.estEndDate = estEndDate;
            this.endDate = endDate;
            this.latlong = latlong;
			this.travelDistance = travelDistance;
        }

		// Used to get unfinish booking
        public Booking(int bookingID, int accountID, String numberPlate, long bookingDate, long startDate,
					long estEndDate, Location latlong) {
            this.bookingID = bookingID;
            this.accountID = accountID;
            this.numberPlate = numberPlate;
            this.startDate = startDate;
            this.latlong = latlong;
        }

		public void debug() {
			Debug.WriteLine("id " + accountID + " book a car for " + startDate);
			latlong.debug();
		}
    }
}