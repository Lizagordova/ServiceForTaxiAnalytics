using ServiceForTaxiAnalytic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ServiceForTaxiAnalytic.Controllers
{
    public class UserHandlerController : Controller
    {
        ServiceContext db = new ServiceContext();
        // GET: UserHandler
        [HttpPost]
       public ActionResult AddRoute(RouteForFinding route)
        {
            db.Routes.Add(route);
            db.SaveChanges();
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}