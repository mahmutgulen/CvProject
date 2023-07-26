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
            var result = _userSocialMediaService.GetUserSocialMedia(1).Data;
            return View(result);
        }
    }
}
