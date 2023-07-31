using CvProject.BLL.Abstract;
using CvProject.ENTITY.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto dto)
        {
            var result=_authService.UserRegister(dto);
            return RedirectToAction("Index", "Auth");
        }
    }
}
