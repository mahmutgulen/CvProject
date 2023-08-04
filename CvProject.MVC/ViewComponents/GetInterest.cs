using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetInterest : ViewComponent
    {
        private readonly IUserInterestService _userInterestService;

        public GetInterest(IUserInterestService userInterestService)
        {
            _userInterestService = userInterestService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var result = _userInterestService.GetUserInterest(userId).Data;
            return View(result);
        }
    }
}
