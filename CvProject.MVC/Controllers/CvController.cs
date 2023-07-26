using CvProject.BLL.Abstract;
using CvProject.ENTITY.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.Controllers
{
    public class CvController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}
