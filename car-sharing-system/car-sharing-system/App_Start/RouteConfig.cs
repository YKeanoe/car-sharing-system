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
                name: "Views/",
                url: "{controller}/Views/",
                defaults: new { controller = "Dashboard" }
            );
            routes.Add("Dashboard", new Route
            (
               "dashboard/",
               new CustomRouteHandler("~/Views/dashboard.aspx")
            ));
            routes.Add("DashboardLogin", new Route
            (
               "dashboard/login",
               new CustomRouteHandler("~/Views/login.aspx")
            ));
            routes.Add("DashboardProfile", new Route
            (
               "dashboard/profile",
               new CustomRouteHandler("~/Views/profile.aspx")
            ));
            routes.Add("DashboardBooking", new Route
            (
               "dashboard/booking",
               new CustomRouteHandler("~/Views/booking.aspx")
            ));
            routes.Add("DashboardIssue", new Route
           (
              "dashboard/issue",
              new CustomRouteHandler("~/Views/issue.aspx")
           ));
            routes.Add("Dashboardlogout", new Route
            (
               "dashboard/logout",
               new CustomRouteHandler("~/Views/logout.aspx")
            ));
            routes.Add("DashboardSuccessReg", new Route
            (
               "dashboard/congratz",
               new CustomRouteHandler("~/Views/successregister.aspx")
            ));
            routes.Add("Dashboardreg", new Route
            (
               "dashboard/register",
               new CustomRouteHandler("~/Views/register.aspx")
            ));
            routes.Add("DashboardDetail", new Route
            (
               "dashboard/detail",
               new CustomRouteHandler("~/Views/detail.aspx")
            ));
            routes.Add("index", new Route
            (
                "",
                new CustomRouteHandler("~/Views/index.aspx")
            ));
            routes.Add("DashboardConfirmBook", new Route
            (
                "dashboard/confirmation",
                new CustomRouteHandler("~/Views/bookingconfirmation.aspx")
            ));
			routes.Add("DashboardReturnBook", new Route
			(
				"dashboard/return",
				new CustomRouteHandler("~/Views/bookingreturn.aspx")
			));
			routes.Add("DashboardSuccessReturn", new Route
			(
			   "dashboard/returnsuccess",
			   new CustomRouteHandler("~/Views/successBook.aspx")
			));
			routes.Add("issuereported", new Route
            (
                "dashboard/issuereported",
                new CustomRouteHandler("~/Views/successIssue.aspx")
            ));
			routes.Add("AdminUsers", new Route
			(
				"dashboard/admin/users",
				new CustomRouteHandler("~/Views/adminusers.aspx")
			));
			routes.Add("AdminCars", new Route
			(
				"dashboard/admin/cars",
				new CustomRouteHandler("~/Views/admincar.aspx")
			));
			routes.Add("AdminAddCar", new Route
			(
				"dashboard/admin/addcar",
				new CustomRouteHandler("~/Views/admincaradd.aspx")
			));
			routes.Add("AdminViewCar", new Route
			(
				"dashboard/admin/car",
				new CustomRouteHandler("~/Views/admincarview.aspx")
			));
			routes.Add("AdminIssues", new Route
			(
				"dashboard/admin/issues",
				new CustomRouteHandler("~/Views/adminissue.aspx")
			));
		}
    }
}
