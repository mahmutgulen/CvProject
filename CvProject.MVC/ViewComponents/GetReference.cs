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
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var result = _userReferenceService.GetUserReference(userId).Data;
            return View(result);
        }
    }
}
