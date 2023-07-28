using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetReference : ViewComponent
    {
        private readonly IUserReferenceService _userReferenceService;

        public GetReference(IUserReferenceService userReferenceService)
        {
            _userReferenceService = userReferenceService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _userReferenceService.GetUserReference(1).Data;
            return View(result);
        }
    }
}
