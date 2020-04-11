using ServiceForTaxiAnalytic.Enums;
using ServiceForTaxiAnalytic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CsvHelper;

namespace ServiceForTaxiAnalytic.Controllers
{
    public class UserHandlerController : Controller
    {
        ServiceContext db = new ServiceContext();

        [HttpPost]
       public ActionResult AddRoute(RouteForFinding route)
        {
            db.Routes.Add(route);
            db.SaveChanges();
            CreateCsvReport(route, ViewBag.UserIp);
            var routeId = db.Routes.FirstOrDefault(m => m.Email == route.Email).RouteForFindingId;//TODO: найди здесь способ другой связи,может быть,с помощью метаданных каких-нибудь или атрибутов
            var userId = ViewBag.UserId;
            var userRoute = new UserRoute { UserId = userId, RouteId = routeId, RequestTime = DateTime.Now, Taxi = Taxi.Yandex };
            db.UserRoutes.Add(userRoute);

            ViewBag.FromCookie = HttpContext.Request.Cookies["id"].Value;
            return View();
        }

        private void CreateCsvReport(RouteForFinding route, int userIp)
        {
            var csvPath = "C://ServiceForTaxiAnalytic//"+userIp.ToString()+"csv";
            var streamWriter = new StreamWriter(csvPath);
            var csvWriter = new CsvHelper.CsvWriter(streamWriter, System.Globalization.CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = "\t";
            if(FileSize(csvPath) == 0)
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
        public ActionResult Index()
        {
            return View();
        }   
    }
}