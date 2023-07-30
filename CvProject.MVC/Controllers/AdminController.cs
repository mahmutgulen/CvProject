using CvProject.BLL.Abstract;
using CvProject.ENTITY.Dtos.AdminAccountDtos;
using CvProject.ENTITY.Dtos.UserDtos;
using CvProject.ENTITY.Dtos.UserExperienceDtos;
using CvProject.ENTITY.Dtos.UserSocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;
using CvProject.ENTITY.Dtos.UserReferenceDtos;
using CvProject.ENTITY.Dtos.UserSkillDtos;
using CvProject.ENTITY.Dtos.UserEducationDtos;
using CvProject.ENTITY.Dtos.UserCertificateDtos;
using System.Transactions;
using CvProject.ENTITY.Dtos.UserLanguageDtos;

namespace CvProject.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminAccountService _adminAccountService;
        private readonly IAuthService _authService;
        private readonly IUserSocialMediaService _userSocialMediaService;
        private readonly IUserExperienceService _experienceService;
        private readonly IUserReferenceService _userReferenceService;
        private readonly IUserSkillService _skillService;
        private readonly IUserEducationService _educationService;
        private readonly IUserCertificateService _certificateService;
        private readonly IUserLanguageService _languageService;

        public AdminController(IAdminAccountService adminAccountService, IAuthService authService, IUserSocialMediaService userSocialMediaService, IUserExperienceService experienceService, IUserReferenceService userReferenceService, IUserSkillService skillService, IUserEducationService educationService, IUserCertificateService certificateService, IUserLanguageService languageService)
        {
            _adminAccountService = adminAccountService;
            _authService = authService;
            _userSocialMediaService = userSocialMediaService;
            _experienceService = experienceService;
            _userReferenceService = userReferenceService;
            _skillService = skillService;
            _educationService = educationService;
            _certificateService = certificateService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("AdminAccount", "Admin");
        }
        [HttpGet]
        public IActionResult AdminPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminPassword(UserPasswordChangeDto dto)
        {
            dto.UserId = 1;
            var result = _authService.UserPasswordChange(dto);
            return RedirectToAction("AdminAccount", "Admin");
        }

        [HttpGet]
        public IActionResult AdminAccount()
        {
            var result = _adminAccountService.GetAdminAccount(1).Data;
            return View(result);
        }

        [HttpPost]
        public IActionResult AdminAccount(GetAdminAccountDto dto)
        {
            dto.UserId = 1;
            var result = _adminAccountService.UpdateAdminAccount(dto);
            ViewBag.Message = result.MessageCode;
            return RedirectToAction("AdminAccount", "Admin");
        }

        [HttpGet]
        public IActionResult AdminSocialMedia()
        {
            var result = _userSocialMediaService.GetUserSocialMedia(1).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(AddSocialMediaDto dto)
        {
            dto.UserId = 1;
            dto.SocialMediaIcon = "fab fa-" + dto.SocialMediaName.ToLower();
            var result = _userSocialMediaService.AddSocialMedia(dto);
            return RedirectToAction("AdminSocialMedia", "Admin");
        }

        [HttpGet]
        public IActionResult DeleteSocialMedia(int id)
        {
            var result = _userSocialMediaService.DeleteSocialMedia(id);
            return RedirectToAction("AdminSocialMedia", "Admin");
        }

        [HttpGet]
        public IActionResult AdminExperience()
        {
            var result = _experienceService.GetUserExperience(1).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteExperience(int id)
        {
            var result = _experienceService.DeleteExperience(id);
            return RedirectToAction("AdminExperience", "Admin");
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(AddExperienceDto dto)
        {
            dto.UserId = 1;
            var result = _experienceService.AddExperiece(dto);
            return RedirectToAction("AdminExperience", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var result = _experienceService.GetByIdExperience(id).Data;
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateExperience(UpdateExperienceDto dto)
        {
            var result = _experienceService.UpdateExperiece(dto);
            return RedirectToAction("AdminExperience", "Admin");
        }

        [HttpGet]
        public IActionResult AdminReference()
        {
            var result = _userReferenceService.GetUserReference(1).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteReference(int id)
        {
            var result = _userReferenceService.DeleteReference(id);
            return RedirectToAction("AdminReference", "Admin");
        }

        [HttpGet]
        public IActionResult AddReference()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReference(AddUserReferenceDto dto)
        {
            dto.UserId = 1;
            var result = _userReferenceService.AddReference(dto);
            return RedirectToAction("AdminReference", "Admin");
        }

        [HttpGet]
        public IActionResult AdminSkill()
        {
            var result = _skillService.GetUserSkill(1).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteSkill(int id)
        {
            var result = _skillService.DeleteSkill(id);
            return RedirectToAction("AdminSkill", "Admin");
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(AddUserSkillDto dto)
        {
            dto.UserId = 1;
            var result = _skillService.AddSkill(dto);
            return RedirectToAction("AdminSkill", "Admin");
        }

        [HttpGet]
        public IActionResult AdminEducation()
        {
            var result = _educationService.GetUserEducation(1).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteEducation(int id)
        {
            var result = _educationService.DeleteEducation(id);
            return RedirectToAction("AdminEducation", "Admin");
        }

        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEducation(AddUserEducationDto dto)
        {
            dto.UserId = 1;
            var result = _educationService.AddEducation(dto);
            return RedirectToAction("AdminEducation", "Admin");
        }


        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var result = _educationService.GetByIdUserEducation(id).Data;
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateEducation(UpdateUserEducationDto dto)
        {
            var result = _educationService.UpdateEducation(dto);
            return RedirectToAction("AdminEducation", "Admin");
        }

        [HttpGet]
        public IActionResult AdminCertificate()
        {
            var result = _certificateService.GetUserCertificate(1).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteCertificate(int id)
        {
            var result = _certificateService.DeleteUserCertificate(id);
            return RedirectToAction("AdminCertificate", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateCertificate(int id)
        {
            var result = _certificateService.GetByIdUserCertificate(id).Data;
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateCertificate(UpdateUserCertifiacateDto dto)
        {
            var result = _certificateService.UpdateCertificate(dto);
            return RedirectToAction("AdminCertificate", "Admin");
        }


        [HttpGet]
        public IActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCertificate(AddUserCertificateDto dto)
        {
            dto.UserId = 1;
            var result = _certificateService.AddCertificate(dto);
            return RedirectToAction("AdminCertificate", "Admin");
        }

        [HttpGet]
        public IActionResult AdminLanguage()
        {
            var result = _languageService.GetUserLanguage(1).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteLanguage(int id)
        {
            var result = _languageService.DeleteUserLanguage(id);
            return RedirectToAction("AdminLanguage", "Admin");
        }

        [HttpGet]
        public IActionResult AddLanguage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLanguage(AddUserLanguageDto dto)
        {
            dto.UserId = 1;
            var result = _languageService.AddUserLanguage(dto);
            return RedirectToAction("AdminLanguage", "Admin");
        }
    }
}

