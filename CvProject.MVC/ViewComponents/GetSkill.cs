using CvProject.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.MVC.ViewComponents
{
    public class GetSkill : ViewComponent
    {
        private readonly IUserSkillService _userSkillService;

        public GetSkill(IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _userSkillService.GetUserSkill(1).Data;
            return View(result);
        }
    }
}
