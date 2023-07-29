using CvProject.BLL.Abstract;
using CvProject.ENTITY.Dtos.AdminAccountDtos;
using CvProject.ENTITY.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminAccountService _adminAccountService;
        private readonly IAuthService _authService;

        public AdminController(IAdminAccountService adminAccountService, IAuthService authService)
        {
            _adminAccountService = adminAccountService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("AdminAccount", "Admin");
        }
        [HttpGet]
        public IActionResult AdminPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminPassword(UserPasswordChangeDto dto)
        {
            dto.UserId = 1;
            var result = _authService.UserPasswordChange(dto);
            return RedirectToAction("AdminAccount", "Admin");
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
