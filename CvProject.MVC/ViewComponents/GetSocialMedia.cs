using CvProject.BLL.Abstract;
using CvProject.DAL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetSocialMedia : ViewComponent
    {
        private readonly IUserSocialMediaService _userSocialMediaService;

        public GetSocialMedia(IUserSocialMediaService userSocialMediaService)
        {
            _userSocialMediaService = userSocialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var result = _userSocialMediaService.GetUserSocialMedia(userId).Data;
            return View(result);
        }
    }
}
