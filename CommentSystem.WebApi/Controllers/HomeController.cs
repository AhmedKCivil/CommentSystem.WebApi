using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommentSystem.WebApi.Controllers
{
	public class HomeController : Controller
	{
		/// <summary>
		/// Displays the Swagger API doc page
		/// </summary>
		/// <returns></returns>
		public ActionResult Swagger()
		{
			return Redirect("~/swagger");
		}
	}
}
