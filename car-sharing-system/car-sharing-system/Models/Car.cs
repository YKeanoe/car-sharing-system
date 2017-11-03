using System;
using System.Text;

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

		public Double rangeToUser { get; set; }

		public char status { get; set; }

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
				Boolean cruiseControl ,
				Boolean reverseCam,
				Boolean radio) {

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
			this.cruiseControl = cruiseControl;
			this.reverseCam = reverseCam;
			this.radio = radio;
		}

		public Car(String numberPlate, Location latlong, String brand, String model, double rate) {
			this.numberPlate = numberPlate;
			this.brand = brand;
			this.model = model;
			this.rate = rate;
			this.latlong = latlong;
		}

        public Car() {
            this.numberPlate = null;
            this.latlong = null;
            this.country = null;
            this.brand = null;
            this.model = null;
            this.vehicleType = null;
            this.seats = 0;
            this.doors = 0;
            this.transmission = 'A';
            this.status = 'A';
            this.fuelType = null;
            this.tankSize = 0;
            this.fuelConsumption = 0;
            this.avgRange = 0;
            this.rate = 0;
            this.cdPlayer = false;
            this.gps = false;
            this.bluetooth = false;
            this.cruiseControl = false;
            this.reverseCam = false;
            this.radio = false;
        }


        public Car(String numberPlate, String brand, String model, String vehicleType, double rate, char status) {
			this.numberPlate = numberPlate;
			this.brand = brand;
			this.model = model;
			this.vehicleType = vehicleType;
			this.rate = rate;
			this.status = status;
		}

		public String getCarAsTitle() {
			return brand + " " + model + " (" + numberPlate + ")";
		}

		public void debug() {
			System.Diagnostics.Debug.WriteLine(numberPlate + " | " + brand + " | " + model + " | " + latlong.ToString());
		}
		public void fulldebug() {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0} | {1} {2} | {3}", numberPlate, brand, model, latlong.ToString());
			sb.Append(Environment.NewLine);
			sb.AppendFormat("{0} | {1} Seats | {2} doors | {3}", vehicleType, seats, doors, transmission);
			System.Diagnostics.Debug.WriteLine(sb);
		}
	}
}