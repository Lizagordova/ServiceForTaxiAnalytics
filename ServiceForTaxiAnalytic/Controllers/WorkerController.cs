using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceForTaxiAnalytic.Controllers
{
    public class WorkerController : Controller
    {
        // GET: Worker
        public ActionResult Index()
        {
            return View();
        }

        public HtmlString FromCsvToHtml(string path)
        {
            var somethingRead = "";//TODO:открыть csv-файл,превратить содержимое в нужные HTML
            var htmlResult = new HtmlString(somethingRead);

            return htmlResult;
        }
    }
}