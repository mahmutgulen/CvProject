using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.UI.Controllers
{
    public class CvController : Controller
    {
        // GET: Cv
        public ActionResult Index()
        {
            return View();
        }
    }
}