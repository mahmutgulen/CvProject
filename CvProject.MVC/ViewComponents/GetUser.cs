using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetUser : ViewComponent
    {
        private readonly IUserService _userService;

        public GetUser(IUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _userService.GetUser(1).Data;

            return View(result);
        }
    }
}
