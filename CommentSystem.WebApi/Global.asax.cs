using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;


namespace CommentSystem.WebApi
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AutoMapperConfig.Configure();
			AutoFacConfig.Configure(GlobalConfiguration.Configuration);
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

		}

#pragma warning disable RECS0154 // Parameter is never used
		protected void Application_BeginRequest(object sender, EventArgs e)
#pragma warning restore RECS0154 // Parameter is never used
		{
			// https://www.codeproject.com/Tips/1022870/AngularJS-Web-API-Active-Directory-Security
			if ((Context.Request.Path.Contains("api/") || Context.Request.Path.Contains("odata/")) && Context.Request.HttpMethod == "OPTIONS")
			{
				Context.Response.AddHeader("Access-Control-Allow-Origin", Context.Request.Headers["Origin"]);
				Context.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
				Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
				Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
				Context.Response.End();
			}
		}
	}
}
