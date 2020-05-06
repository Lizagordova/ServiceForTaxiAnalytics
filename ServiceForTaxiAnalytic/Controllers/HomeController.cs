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
		var locations = new List<Location>();
		string connectionString = "Server=tcp:portfolio25.database.windows.net,1433;Initial Catalog=WhatIsNextToMe_db;Persist Security Info=False;User ID=Elizaveta;Password=Uav7bha2309";
		var sql = "Select * from Location";
		using (var connection = new SqlConnection(connectionString))
		{
			connection.Open();
			var command = new SqlCommand(sql, connection);
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					var location = new Location();
					location.Name = reader.GetValue(1).ToString();
					switch (reader.GetValue(2).ToString())
					{
						case "1":
							location.Type = 1;
							break;
						case "2":
							location.Type = 2;
							break;
						case "3":
							location.Type = 3;
							break;
					}
					locations.Add(location);
				}
			}
		}
		return View(locations);
	}

	public ActionResult UserRequest()
	{
		var cafes = new List<Cafe>();
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
					var cafe = new Cafe();
					cafe.Name = reader.GetValue(1).ToString();
					cafe.Address = reader.GetValue(2).ToString();
					ViewBag.Name = ViewBag.Name + reader.GetValue(1);
					ViewBag.Address = ViewBag.Address + reader.GetValue(2);
					cafes.Add(cafe);
					ViewBag.Cafes = ViewBag.Cafes + cafe;
				}
			}
		}

		return View(cafes);
	}
	public JsonResult GetCafes()
	{
		var cafes = new List<Cafe>();
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
					var cafe = new Cafe();
					cafe.Name = reader.GetValue(1).ToString();
					cafe.Address = reader.GetValue(2).ToString();
					ViewBag.Cafes = ViewBag.Cafes + cafe;
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