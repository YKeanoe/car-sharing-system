using System;
using System.Web.Security;
using System.Web;
namespace car_sharing_system.Models
{
    public class UserModel
    {
        public static user loginAttempt(String email, String password) {
            return DatabaseReader.userQuerySingle("email = '" + email + "' and password = '"+password+"';");
        }

		public static bool isAdmin(HttpCookie authCookie) {
			//HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
			int permission = Int32.Parse(ticket.UserData);
			if (permission == 1) {
				return true;
			} else {
				return false;
			}

		}
	}
}