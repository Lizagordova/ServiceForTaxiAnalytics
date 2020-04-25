using ServiceForTaxiAnalytic.YandexTaxi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceForTaxiAnalytic.YandexTaxi.Models
{
	public class YandexRequestModel
	{
		public string Clide { get; set; }
		public string ApiKey { get; set; }
		public string Rll { get; set; }//TODO: тут особый формат
		public Tarif Class { get; set; } = Tarif.Econom;
		public Req Req { get; set; }
		public Language Language { get; set; }
	}
}