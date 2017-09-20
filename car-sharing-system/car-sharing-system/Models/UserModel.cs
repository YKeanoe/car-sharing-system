using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{
    public class UserModel
    {
        public UserModel() {

        }

        public User loginAttempt(String email, String password)
        {
            return DatabaseReader.userQuerySingle("email = '" + email + "' and password = '"+password+"';");
        }
    }
}