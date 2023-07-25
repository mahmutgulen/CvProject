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
        public IActionResult GetUser(int id=1)
        {
            var result = _userService.GetUser(id).Data;
            return View(result);
        }

    }
}
