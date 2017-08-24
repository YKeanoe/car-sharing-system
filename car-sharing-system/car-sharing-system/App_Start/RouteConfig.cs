using car_sharing_system.App_Start;
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
                url: "{controller}/pages/",
                defaults: new { controller = "Dashboard" }
            );
            routes.Add("Dashboard", new Route
            (
               "dashboard/",
               new CustomRouteHandler("~/Views/Admin_Theme/pages/index.aspx")
            ));
            routes.Add("Dashboardindex2", new Route
            (
               "dashboard/index",
               new CustomRouteHandler("~/Views/Admin_Theme/pages/index.aspx")
            ));
            routes.Add("DashboardLogin", new Route
            (
               "dashboard/login",
               new CustomRouteHandler("~/Views/Admin_Theme/pages/login.aspx")
            ));
            routes.Add("DashboardProfile", new Route
            (
               "dashboard/profile",
               new CustomRouteHandler("~/Views/Admin_Theme/pages/profile.aspx")
            ));
            routes.Add("DashboardBooking", new Route
            (
               "dashboard/booking",
               new CustomRouteHandler("~/Views/Admin_Theme/pages/booking.aspx")
            ));
            routes.Add("DashboardIssue", new Route
           (
              "dashboard/issue",
              new CustomRouteHandler("~/Views/Admin_Theme/pages/issue.aspx")
           ));
            routes.Add("Dashboardlogout", new Route
            (
               "dashboard/logout",
               new CustomRouteHandler("~/Views/Admin_Theme/pages/logout.aspx")
            ));
            routes.Add("DashboardSuccessReg", new Route
            (
               "dashboard/congratz",
               new CustomRouteHandler("~/Views/Admin_Theme/pages/successregister.aspx")
            ));
            routes.Add("Dashboardreg", new Route
            (
               "dashboard/register",
               new CustomRouteHandler("~/Views/Admin_Theme/pages/register.aspx")
            ));
            routes.Add("DashboardDetail", new Route
            (
               "dashboard/detail",
               new CustomRouteHandler("~/Views/Admin_Theme/pages/detail.aspx")
            ));
        }
    }
}
