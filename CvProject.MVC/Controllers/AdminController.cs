using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("AdminAccount", "Admin");
        }

        public IActionResult AdminPassword()
        {
            return View();
        }

        public IActionResult AdminAccount()
        {
            return View();
        }
    }
}
