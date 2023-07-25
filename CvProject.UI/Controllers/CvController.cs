using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CvProject.UI.Controllers
{
	public class CvController : Controller
	{
		// GET: Cv
		private readonly IUserService _userService;

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult GetUser()
		{
			var result = _userService.GetUser(1);
			return View(result);
		}
	}
}