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
        public String licenceNo { get; private set; }
        public String fname { get; private set; }
        public String lname { get; private set; }
        public String gender { get; private set; }
        public String birth { get; private set; }
        public String phone { get; private set; }
        public String street { get; private set; }
        public String suburb { get; private set; }
        public String postcode { get; private set; }
        public String territory { get; private set; }
        public String city { get; private set; }
        public String country { get; private set; }
        public String profileURL { get; private set; }


        public User(int id,
            String email,
            String password,
            int permission,
            String licenceNo,
            String fname,
            String lname,
            String gender,
            String birth,
            String phone,
            String street,
            String suburb,
            String postcode,
            String territory,
            String city,
            String country,
            String profileURL)
        {



            this.id = id;
            this.email = email;
            this.password = password;
            this.permission = permission;
            this.licenceNo = licenceNo;
            this.fname = fname;
            this.lname = lname;
            this.gender = gender;
            this.birth = birth;
            this.phone = phone;
            this.street = street;
            this.suburb = suburb;
            this.postcode = postcode;
            this.territory = territory;
            this.city = city;
            this.country = country;
            this.profileURL = profileURL;




        }

        public String toString()
        {
            return "ID: " + id + "<br />" +
                "Email: " + email + "<br />" +
                "Password: " + password + "<br />" +
                "Permission: " + permission + "<br />" +
                "LicenceNo: " + licenceNo + "<br />" +
                "First Name: " + fname + "<br />" +
                "Last Name: " + lname + "<br />" +
                "Gender: " + gender + "<br />" +
                "Date Of Birth: " + birth + "<br />" +
                "Phone: " + birth + "<br />" +
                "Street: " + birth + "<br />" +
                "Suburb: " + birth + "<br />" +
                "Postcode: " + birth + "<br />" +
                "Territory: " + birth + "<br />" +
                "City: " + birth + "<br />" +
                "Country: " + birth + "<br />" +
                "ProfileURL: " + birth + "<br />";


        }
    }
}