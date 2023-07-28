using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetLanguage : ViewComponent
    {
        private readonly IUserLanguageService _userLanguageService;

        public GetLanguage(IUserLanguageService userLanguageService)
        {
            _userLanguageService = userLanguageService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _userLanguageService.GetUserLanguage(1).Data;
            return View(result);
        }
    }
}
