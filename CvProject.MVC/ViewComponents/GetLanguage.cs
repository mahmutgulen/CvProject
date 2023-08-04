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
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var result = _userLanguageService.GetUserLanguage(userId).Data;
            return View(result);
        }
    }
}
