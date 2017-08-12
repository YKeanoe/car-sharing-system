using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{
  public class Car {
    String numberPlate;
    String brand;
    String model;
    String vehicleType;
    int seats;
    double rate;
    double coorX;
    double coorY;

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

    public string NumberPlate {
      get {
        return numberPlate;
      }
      set {
        numberPlate = value;
      }
    }

    public string Brand {
      get {
        return brand;
      }
      set {
        brand = value;
      }
    }

    public string Model {
      get {
        return model;
      }
      set {
        model = value;
      }
    }

    public string VehicleType {
      get {
        return vehicleType;
      }
      set {
        vehicleType = value;
      }
    }

    public int Seats {
      get {
        return seats;
      }
      set {
        seats = value;
      }
    }
    public double Rate {
      get {
        return rate;
      }
      set {
        rate = value;
      }
    }

    public double CoorX {
      get {
        return coorX;
      }
      set {
        coorX = value;
      }
    }

    public double CoorY {
      get {
        return coorY;
      }
      set {
        coorY = value;
      }
    }
    
  }
}