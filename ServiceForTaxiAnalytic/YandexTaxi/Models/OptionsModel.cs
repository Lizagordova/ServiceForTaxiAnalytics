using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceForTaxiAnalytic.YandexTaxi.Models
{
	public class OptionsModel
	{
		[JsonProperty(PropertyName = "class_name")]
		public string ClassName { get; set; }
		[JsonProperty(PropertyName = "class_level")]
		public double ClassLevel { get; set; }
		[JsonProperty(PropertyName = "class_text")]
		public string ClassText { get; set; }
		[JsonProperty(PropertyName = "min_price")]
		public double MinPrice { get; set; }
		[JsonProperty(PropertyName = "price")]
		public double Price { get; set; }
		[JsonProperty(PropertyName = "waiting_time")]
		public double WaitingTime { get; set; }
	}
}