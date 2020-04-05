using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServiceForTaxiAnalytic.Models
{
	public class ServiceDbInitializer : DropCreateDatabaseAlways<ServiceContext>
	{
		protected override void Seed(ServiceContext db)
		{
			base.Seed(db);
		}
	}
}