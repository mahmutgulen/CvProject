using CvProject.BLL.Abstract;
using CvProject.ENTITY.Dtos.AdminAccountDtos;
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

        [HttpPost]
        public IActionResult AdminAccount(GetAdminAccountDto dto)
        {
            dto.UserId = 1;
            var result = _adminAccountService.UpdateAdminAccount(dto);
            ViewBag.Message = result.MessageCode;
            return RedirectToAction("AdminAccount", "Admin");
        }
    }
}
