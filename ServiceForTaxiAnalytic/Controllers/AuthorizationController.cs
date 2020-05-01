using System;
using System.Web.Mvc;
using ServiceForTaxiAnalytic.Enums;

namespace ServiceForTaxiAnalytic.Controllers
{
	public class AuthorizationController : Controller
	{
		// GET
		[HttpPost]
		public ActionResult Authorization(string what/*AuthorizationType type*/)
		{
			switch (what)
			{
				case "registration":
					return Entrance();
				case "entrance":
					return Registration();
			};
/*switch (type)
{
	case AuthorizationType.Entrance:
		return Entrance();
	case AuthorizationType.Registration:
		return Registration();
};*/
return Registration();
}

private ActionResult Registration()
{
return View("Registration");
}

private ActionResult Entrance()
{
return View("Entrance");
}
}
}