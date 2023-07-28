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
            var result = _userInterestService.GetUserInterest(1).Data;
            return View(result);
        }
    }
}
