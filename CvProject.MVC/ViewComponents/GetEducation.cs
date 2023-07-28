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
            var result = _userEducationService.GetUserEducation(1).Data;
            return View(result);
        }
    }
}
