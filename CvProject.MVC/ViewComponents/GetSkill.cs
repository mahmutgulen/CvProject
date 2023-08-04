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
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var result = _userSkillService.GetUserSkill(userId).Data;
            return View(result);
        }
    }
}
