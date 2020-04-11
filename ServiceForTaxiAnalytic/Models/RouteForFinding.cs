using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceForTaxiAnalytic.Models
{
	public class RouteForFinding
	{
		public int RouteForFindingId { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; } 
		public string Email { get; set; }//TODO: e-mail лучше только у юзера оставить
	}
}