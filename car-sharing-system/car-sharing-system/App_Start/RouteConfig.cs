using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace car_sharing_system
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Views/Admin_Theme/pages",
                url: "dashboard/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
