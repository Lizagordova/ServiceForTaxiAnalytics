using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServiceForTaxiAnalytic.Models
{
	public class ServiceContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<RouteForFinding> Routes { get; set; }
	}
}