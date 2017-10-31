using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace car_sharing_system { 
	public static class WebApiConfig {
		public static void Register(HttpConfiguration config) {
			// TODO: Add any additional configuration code.

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			// Change to text instead of xml
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

		}
	}
}