using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceForTaxiAnalytic.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Ip { get; set; }
		public string Email { get; set; } = null;
	}
}