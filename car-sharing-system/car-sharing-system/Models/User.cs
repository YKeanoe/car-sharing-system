using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{

    public class User
    {
        public int id { get; private set; }
        public String email { get; private set; }
        public String password { get; private set; }
        public int permission { get; private set; }
        public String longitude { get; private set; }
        public String latitude { get; private set; }
        public String fname { get; private set; }
        public String lname { get; private set; }
        public String dob { get; private set; }
        public String LicenceNo { get; private set; }

        public User(int id,String email,String password,int permission, String longitude, String latitude,String fname,String lname,String dob,String LicenceNo) {
            this.id = id;
            this.email = email;
            this.password = password;
            this.permission = permission;
            this.longitude = longitude;
            this.latitude = latitude;
            this.fname = fname;
            this.lname = lname;
            this.dob = dob;
            this.LicenceNo = LicenceNo;
        }

        public String toString() {
            return "ID: " + id + "<br />" +
                "Email: " + email + "<br />" +
                "First Name: " + fname + "<br />" +
                "Last Name: " + lname + "<br />" +
                "Password: " + password + "<br />" +
                "Date Of Birth: " + dob + "<br />" +
                "Permission: " + permission + "<br />" +
                "LicenceNo: " + LicenceNo + "<br />" +
                "Longitude: " + longitude + "<br />" +
                "Latitude: " + latitude + "<br />";
        }
    }
}