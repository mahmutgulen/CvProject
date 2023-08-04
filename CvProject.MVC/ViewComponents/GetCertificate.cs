using CvProject.BLL.Abstract;
using CvProject.DAL.Abstract;
using CvProject.DAL.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetCertificate : ViewComponent
    {
        private readonly IUserCertificateService _userCertificateService;

        public GetCertificate(IUserCertificateService userCertificateService)
        {
            _userCertificateService = userCertificateService;
        }


        public IViewComponentResult Invoke()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var result = _userCertificateService.GetUserCertificate(userId).Data;
            return View(result);
        }
    }
}
