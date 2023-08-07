using AspNetCoreHero.ToastNotification.Abstractions;
using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
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
        private readonly IUserDal _userDal;
        private readonly INotyfService _notyf;

        public AuthController(IAuthService authService, IUserDal userDal, INotyfService notyf)
        {
            _authService = authService;
            _userDal = userDal;
            _notyf = notyf;
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
                //userId
                var user = _userDal.Get(x => x.UserName == dto.UserName);
                var userId = user.Id;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,dto.UserName),
                    new Claim(ClaimTypes.NameIdentifier,userId.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                _notyf.Success($"Signed in by {user.UserFirstName}");
                return RedirectToAction("Index", "Admin");
            }
                _notyf.Error(result.Message);
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
            if (result.Data)
            {
                return RedirectToAction("Index", "Auth");
            }
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success("Logged Out");
            }
            _notyf.Error(result.Message);
            return RedirectToAction("Register", "Auth");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            _notyf.Success("Logged Out");

            return RedirectToAction("Index", "Auth");
        }
    }
}
