using CvProject.BLL.Abstract;
using CvProject.ENTITY.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("userregister")]
        public IActionResult UserRegister(UserRegisterDto dto)
        {
            var result = _authService.UserRegister(dto);
            return Ok(result);
        }
    }
}
