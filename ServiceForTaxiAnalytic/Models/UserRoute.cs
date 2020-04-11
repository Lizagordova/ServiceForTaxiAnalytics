using ServiceForTaxiAnalytic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceForTaxiAnalytic.Models
{
	public class UserRoute
	{
		public int UserRouteId { get; set; }//TODO: Сделать отношение один ко многим: один юзер-много маршрутов
		public int UserId { get; set; }
		public int RouteId { get; set; }
		public DateTime RequestTime { get; set; }
		public DateTime SendTime { get; set; }//TODO: здесь лучше сделать,чтобы автоматом высчитывалось время при добавлении RequestTime(на день больше)
		public Taxi Taxi { get; set; }
	}
}