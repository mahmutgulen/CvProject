using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.UI2.Controllers
{
	public class CvController : Controller
	{
		private readonly IUserService _userService;

		public CvController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
