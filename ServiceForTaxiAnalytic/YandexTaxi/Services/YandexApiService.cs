using Newtonsoft.Json;
using ServiceForTaxiAnalytic.YandexTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ServiceForTaxiAnalytic.YandexTaxi.Services
{
	public class YandexApiService
	{
		public void GetPrice()
		{
			using(var client = GetYandexTaxiClient())
			{
				var information = GetInformationAboutRoute(client);
			}
		}

		private async Task<string> GetInformationAboutRoute(HttpClient client)
		{
			var url = "";
			var response = await client.GetAsync(url);
			var content = await response.Content.ReadAsStringAsync();
			if(response.IsSuccessStatusCode)
			{
				var model = JsonConvert.DeserializeObject<YandexResponseModel>(content);

				return model.Options.Price.ToString();
			}
			else
			{
				throw new HttpRequestException("не получается получить ответ от яндекса");
			}
		}
		private HttpClient GetYandexTaxiClient()
		{
			var client = new HttpClient();

			return client;
		}
	}
}