using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{
	public class Car
	{
		public String numberPlate { get; set; }
		public Location latlong { get; set; }
		public String country { get; set; }
		public String brand { get; set; }
		public String model { get; set; }
		public String vehicleType { get; set; }
		public int seats { get; set; }
		public int doors { get; set; }
		public char transmission { get; set; }

		public String fuelType { get; set; }
		public int tankSize { get; set; }

		public double fuelConsumption { get; set; }
		public int avgRange { get; set; }
		public double rate { get; set; }
		
		public Boolean cdPlayer { get; set; }
		public Boolean gps { get; set; }
		public Boolean bluetooth { get; set; }
		public Boolean cruiseControl { get; set; }
		public Boolean reverseCam { get; set; }
		public Boolean radio { get; set; }
		public Boolean airCon { get; set; }

		public Car(String numberPlate, 
				Location latlong ,
				String country ,
				String brand ,
				String model ,
				String vehicleType, 
				int seats ,
				int doors,
				char transmission,
				String fuelType ,
				int tankSize ,
				double fuelConsumption ,
				int avgRange ,
				double rate ,
				Boolean cdPlayer ,
				Boolean gps ,
				Boolean bluetooth ,
				/*Boolean cruiseControl ,
				Boolean reverseCam, */
				Boolean radio,	 
				Boolean airCon ) {
			this.numberPlate = numberPlate;
			this.latlong = latlong;
			this.country = country;
			this.brand = brand;
			this.model = model;
			this.vehicleType = vehicleType;
			this.seats = seats;
			this.doors = doors;
			this.transmission = transmission;
			this.fuelType = fuelType;
			this.tankSize = tankSize;
			this.fuelConsumption = fuelConsumption;
			this.avgRange = avgRange;
			this.rate = rate;
			this.cdPlayer = cdPlayer;
			this.gps = gps;
			this.bluetooth = bluetooth;
			/*this.cruiseControl = cruiseControl;
			this.reverseCam = reverseCam;*/
			this.radio = radio;
			this.airCon = airCon;
		}

		public Car(String numberPlate, Location latlong, String brand, String model, double rate) {
			this.numberPlate = numberPlate;
			this.brand = brand;
			this.model = model;
			this.rate = rate;
			this.latlong = latlong;
		}

		public String getCarAsTitle() {
			return brand + " " + model + " (" + numberPlate + ")";
		}

		public void debug() {
			System.Diagnostics.Debug.WriteLine(numberPlate + " | " + brand + " | " + model + " | " + latlong.ToString());
		}
	}
}