using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{
  public class Car
  {
    public String numberPlate { get; set; }
    public String brand { get; set; }
    public String model { get; set; }
    public String vehicleType { get; set; }
    public int seats { get; set; }
    public double rate { get; set; }
    public double coorX { get; set; }
    public double coorY { get; set; }
    public char transmission { get; set; }
    public int tankSize { get; set; }
    public double fuelConsumption { get; set; }
    public int avgRange { get; set; }

    public Car(string numberPlate, string brand, string model, string vehicleType, int seats, double rate, double coorX, double coorY)
    {
      this.numberPlate = numberPlate;
      this.brand = brand;
      this.model = model;
      this.vehicleType = vehicleType;
      this.seats = seats;
      this.rate = rate;
      this.coorX = coorX;
      this.coorY = coorY;
    }
  }
}