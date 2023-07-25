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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var result = _userService.GetUser(1).Data;
            ViewBag.UserName = result.UserName;
            ViewBag.UserSurname = result.UserSurname;
            ViewBag.UserPhoneNumber = result.UserPhoneNumber;
            ViewBag.UserMail = result.UserMail;
            ViewBag.Position = "Position Get Shit Done!";

            return View(result);
        }

    }
}
