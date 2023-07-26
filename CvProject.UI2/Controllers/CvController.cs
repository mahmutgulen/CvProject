using CvProject.BLL.Abstract;
using CvProject.ENTITY.Dtos.UserDtos;
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
            var result = _userService.GetUser(1).Data;
            return View(result);
        }
       
    }
}
