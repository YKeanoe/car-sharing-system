using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{
    public class Admin : User
    {
        public Admin(int id, String email, String password, int permission, String longitude, String latitude, String fname, String lname, String dob, String noPlate) : base(id,email,password,permission,longitude,latitude,fname,lname,dob,noPlate)
        {

        }
    }
}