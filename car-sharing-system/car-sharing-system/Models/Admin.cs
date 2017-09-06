using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{
    public class Admin : User
    {
        public Admin(int id,
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
            String profileURL) : base(id,email,password,permission,licenceNo,fname,lname,gender,birth,phone,street,suburb,postcode,territory,city,country,profileURL)
        {

        }
    }
}