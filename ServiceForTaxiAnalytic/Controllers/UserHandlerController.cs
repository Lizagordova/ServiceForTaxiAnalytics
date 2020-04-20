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

        
        
        [HttpGet]
        public ActionResult EditRoute(int? id)//TODO: здесь редактирование по другим параметрам сделай
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            RouteForFinding route = db.Routes.Find(id);
            ViewBag.Route = route;
            if(route != null)
            {
                return View("EditRoute");
            }
            return HttpNotFound();
        }
    }
}