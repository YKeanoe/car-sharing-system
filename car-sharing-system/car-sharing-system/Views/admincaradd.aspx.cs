using car_sharing_system.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class admincaradd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            script.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"/Theme/js/addCar.js\"></script>"));
        }

        protected void submit(object sender, EventArgs e) {
            Car newCar = new Car();
            newCar.numberPlate = numberPlate.Text;
            newCar.brand = brand.Text;
            newCar.model = model.Text;
            newCar.vehicleType = Vt.Text;
            newCar.seats = int.Parse(seats.Text);
            newCar.doors = int.Parse(doors.Text);
            newCar.transmission = char.Parse(transmission.Text);
            newCar.fuelType = fT.Text;
            newCar.tankSize = int.Parse(tanksize.Text);
            newCar.fuelConsumption = double.Parse(fC.Text);
            newCar.avgRange = int.Parse(AverageRange.Text);
            newCar.cdPlayer = Boolean.Parse(cdPlayer.Text);
            newCar.radio = Boolean.Parse(radio.Text);
            newCar.gps = Boolean.Parse(gps.Text);
            newCar.cruiseControl = Boolean.Parse(cruiseControl.Text);
            newCar.reverseCam = Boolean.Parse(reverseCamera.Text);
            newCar.bluetooth = Boolean.Parse(bluetooth.Text);
            newCar.status = 'A';
            Location uloc = (Location)HttpContext.Current.Session["userlocation"];

            Random rand = new Random();
            int y = rand.Next(-3, 2);
            Double x = rand.NextDouble();
            Double randlat = y + x;
            decimal lat = uloc.lat + Convert.ToDecimal(randlat);
            decimal lng = uloc.lng + Convert.ToDecimal(randlat);
            uloc.lat = lat;
            uloc.lng = lng;

            newCar.latlong = new Location(lat, lng);
            newCar.country = RegionInfo.CurrentRegion.DisplayName;
            //DatabaseReader.addCar(newCar);
            Debug.WriteLine(newCar.ToString());
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            HttpContext.Current.Session.Remove("userlocation");
        }

        [System.Web.Services.WebMethod]
        public static void setLoc(String lat, String lng)
        {
            HttpContext.Current.Session["userlocation"] = new Location(Convert.ToDecimal(lat), Convert.ToDecimal(lng));
        }
    }
}