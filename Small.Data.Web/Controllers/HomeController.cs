using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Small.Data.Dat;

namespace Small.Data.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = String.Format("{0} @ {1}",  "Welcome to Small Data", DateTime.Now.ToLongTimeString());

			// Create the db
			Db.CreateDatabase();

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
