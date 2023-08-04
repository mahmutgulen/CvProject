using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetEducation : ViewComponent
    {
        private readonly IUserEducationService _userEducationService;

        public GetEducation(IUserEducationService userEducationService)
        {
            _userEducationService = userEducationService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var result = _userEducationService.GetUserEducation(userId).Data;
            return View(result);
        }
    }
}
