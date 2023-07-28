using CvProject.BLL.Abstract;
using CvProject.DAL.Abstract;
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
            var result = _userCertificateService.GetUserCertificate(1).Data;
            return View(result);
        }
    }
}
