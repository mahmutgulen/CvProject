using CvProject.BLL.Abstract;
using CvProject.ENTITY.Dtos.UserDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto dto)
        {
            var result = _authService.UserLogin(dto);
            if (result.Data)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,dto.UserName),
                };
                var claimsIdentity= new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Auth");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto dto)
        {
            var result = _authService.UserRegister(dto);
            return RedirectToAction("Index", "Auth");
        }
    }
}
