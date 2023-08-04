using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetExperience : ViewComponent
    {
        private readonly IUserExperienceService _userExperienceService;

        public GetExperience(IUserExperienceService userExperienceService)
        {
            _userExperienceService = userExperienceService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var result = _userExperienceService.GetUserExperience(userId).Data;
            return View(result);
        }
    }
}
