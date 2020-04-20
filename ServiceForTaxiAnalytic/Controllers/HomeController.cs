using ServiceForTaxiAnalytic.Enums;
using ServiceForTaxiAnalytic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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

            CreateCsvReport(route);
            var routeId = db.Routes.FirstOrDefault(m => m.Email == route.Email).RouteForFindingId;//TODO: найди здесь способ другой связи,может быть,с помощью метаданных каких-нибудь или атрибутов
           var userId = ViewBag.UserId;
            var FromCookie = HttpContext.Request.Cookies["id"].Value;
            var log = new Log();
            log.LogInfo = FromCookie.ToString();
            db.Logs.Add(log);
          var userRoute = new UserRoute { UserId = int.Parse(FromCookie), RouteId = routeId, RequestTime = DateTime.Now, Taxi = Taxi.Yandex };
            db.UserRoutes.Add(userRoute);

            ViewBag.FromCookie = HttpContext.Request.Cookies["id"].Value;
            return View("AddRoute");
		}

        [HttpGet]
        public ActionResult EditRoute(int? id=1)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            RouteForFinding route = db.Routes.Find(id);
            if(route != null)
            {
                return View(route);
            }
            return HttpNotFound(); 
        }

        [HttpPost]
        public ActionResult EditRoute(RouteForFinding route)
        {
            route.DateFrom = DateTime.Now;
            route.DateTo = DateTime.Now;
            db.Entry(route).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("MainPage");
        }

        [HttpGet]
        public ActionResult AddNewRoute()
        {
            return View("MainPage");
        }

        [HttpPost]
        public ActionResult AddNewRoute(RouteForFinding route)
        {
            MainPage(route);
            return RedirectToAction("MainPage");
        }

        [HttpPost]
        public ActionResult DeleteRoute(int? id)
        {
            RouteForFinding route = db.Routes.Find(id);
            if(route != null)
            {
                db.Routes.Remove(route);
                db.SaveChanges();
            }
            return RedirectToAction("MainPage");
        }
        private void CreateCsvReport(RouteForFinding route)//TODO: Разберись почему это не работает
        {
            var csvPath = "C:\\ServiceForTaxiAnalytic\\" + 12.ToString() + ".csv";
            var streamWriter = new StreamWriter(csvPath);
            var csvWriter = new CsvHelper.CsvWriter(streamWriter, System.Globalization.CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = "\t";
            if (FileSize(csvPath) == 0)
            {
                csvWriter.WriteField("DateTime");
                csvWriter.WriteField("Price");
                csvWriter.NextRecord();
            }
            csvWriter.WriteField(DateTime.Now.ToString());
            csvWriter.WriteField(1234.ToString());
            csvWriter.NextRecord();
            csvWriter = null;
            streamWriter.Close();
        }

        private long FileSize(string path)
        {
            FileInfo file = new FileInfo(path);
            return file.Length;
        }
    }
}