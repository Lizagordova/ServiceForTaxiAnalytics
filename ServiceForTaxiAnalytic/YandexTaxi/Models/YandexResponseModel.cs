using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceForTaxiAnalytic.YandexTaxi.Models
{
	public class YandexResponseModel
	{
		[JsonProperty(PropertyName = "currency")]
		public string Currency { get; set; }//TODO:здесь в будущем потребуется маппинг
		[JsonProperty(PropertyName = "distance")] 
		public double Distance { get; set; }
		[JsonProperty(PropertyName = "options")]
		public OptionsModel Options { get; set; }
	}
}