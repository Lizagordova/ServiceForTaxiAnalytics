using ServiceForTaxiAnalytic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceForTaxiAnalytic.Controllers
{
	public class HomeController : Controller
	{
		ServiceContext db = new ServiceContext();
		public ActionResult MainPage()
		{
			string ip = HttpContext.Request.UserHostAddress;
			HttpContext.Response.Cookies["id"].Value = "12";//TODO: разберись получше с куками!!!
			var user = new User() {Ip = ip };
			db.Users.Add(user);
			db.SaveChanges();
			ViewBag.UserId = db.Users.FirstOrDefault(m => m.Ip == ip).UserId;
			ViewBag.UserIp = ip;
			return View();
		}

		[HttpPost]
		public ActionResult MainPage(RouteForFinding route)
		{
			route.DateFrom = DateTime.Now;
			route.DateTo = DateTime.Now;
			db.Routes.Add(route);
			db.SaveChanges();
			return View("AddRoute");
		}

		
	}
}