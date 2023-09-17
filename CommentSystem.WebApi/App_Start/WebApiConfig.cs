using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CommentSystem.WebApi
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// enable cross site requests using CORS - note, this relies on the Microsoft.AspNet.WebApi.Cors NuGet package being installed
			config.EnableCors(new EnableCorsAttribute("*", "*", "*")
			{
				SupportsCredentials = true
			});

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);


			// show full 500 error messages when deployed
			config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
		}
	}
}
