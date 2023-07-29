using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminAccountService _adminAccountService;

        public AdminController(IAdminAccountService adminAccountService)
        {
            _adminAccountService = adminAccountService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("AdminAccount", "Admin");
        }

        public IActionResult AdminPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminAccount()
        {
            var result = _adminAccountService.GetAdminAccount(1).Data;
            return View(result);
        }
    }
}
