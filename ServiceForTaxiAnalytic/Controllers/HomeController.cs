using ServiceForTaxiAnalytic.Enums;
using ServiceForTaxiAnalytic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ServiceForTaxiAnalytic.Controllers
{
	public class HomeController : Controller
	{
		ServiceContext db = new ServiceContext();
		//private  Regex _regex = new Regex(@"row-shop-desk-block"> <p><small>");
		public ActionResult MainPageWithoutAuthorization()
		{
			//string connectionString = @"Data Source=portfolio25.database.windows.net;Initial Catalog=WhatIsNextTo;User ID=Elizaveta;Password=Uav7bha2309;Connect Timeout=100;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
			string connectionString = "Server=tcp:portfolio25.database.windows.net,1433;Initial Catalog=WhatIsNextToMe_db;Persist Security Info=False;User ID=Elizaveta;Password=Uav7bha2309";
			string sql = "select * from Cafes";
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				var command = new SqlCommand(sql, connection);
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						ViewBag.Name = reader.GetValue(1);
					}
				}
			}
			/*string ip = HttpContext.Request.UserHostAddress;
			HttpContext.Response.Cookies["id"].Value = "12";//TODO: разберись получше с куками!!!
			var user = new User() {Ip = ip };
			db.Users.Add(user);
			db.SaveChanges();
			ViewBag.UserId = db.Users.FirstOrDefault(m => m.Ip == ip).UserId;
			ViewBag.UserIp = ip;*/
			return View();
		}

		public ActionResult MainPage()
		{
			return View();
		}

		public ActionResult ApiYandex()
		{
			var webClient = new WebClient();
			var webRequest = WebRequest.Create("https://www.karavaevi.ru/about/adress.php");
			var webResponse = webRequest.GetResponse();
			using (var stream = webResponse.GetResponseStream())
			{
				using (var reader = new StreamReader(stream))
				{
					string line = "";
					while ((line = reader.ReadLine()) != null)
					{
						ViewBag.Response = ViewBag.Response + line;
					}
				}
			}
			return View();
		}
		public ActionResult MyRoutes()
		{
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