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
            var result = _userDescriptionService.GetUserDescription(1).Data;
            return View(result);
        }
    }
}
