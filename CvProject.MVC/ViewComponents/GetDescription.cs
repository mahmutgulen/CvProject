using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetDescription : ViewComponent
    {
        private readonly IUserDescriptionService _userDescriptionService;

        public GetDescription(IUserDescriptionService userDescriptionService)
        {
            _userDescriptionService = userDescriptionService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var result = _userDescriptionService.GetUserDescription(userId).Data;
            return View(result);
        }
    }
}
