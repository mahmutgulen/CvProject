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
            var result = _userExperienceService.GetUserExperience(1).Data;
            return View(result);
        }
    }
}
