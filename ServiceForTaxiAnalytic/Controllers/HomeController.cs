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
using System.Web;
using System.Web.Mvc;

namespace ServiceForTaxiAnalytic.Controllers
{
	public class HomeController : Controller
	{
	public ActionResult MainPage()
	{
			return View();
	}

	public ActionResult UserRequest()
	{
		Session["City"] = Request.Form["City"];
		Session["Street"] = Request.Form["Street"];
		Session["House"] = Request.Form["House"];
		return View();
	}
	public JsonResult GetCafes()
	{
		List<Cafes> cafes = new List<Cafes>();
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
		return Json(cafes, JsonRequestBehavior.AllowGet);
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
		

    }
}