using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetPhoto : ViewComponent
    {
        private readonly IUserDal _userDal;

        public GetPhoto(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IViewComponentResult Invoke()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            var image = _userDal.Get(x => x.Id == userId).UserImage;
            ViewBag.Image = image;
            return View();
        }
    }
}
