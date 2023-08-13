using CvProject.BLL.Abstract;
using CvProject.ENTITY.Dtos.AdminAccountDtos;
using CvProject.ENTITY.Dtos.UserDtos;
using CvProject.ENTITY.Dtos.UserExperienceDtos;
using CvProject.ENTITY.Dtos.UserSocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using CvProject.ENTITY.Dtos.UserReferenceDtos;
using CvProject.ENTITY.Dtos.UserSkillDtos;
using CvProject.ENTITY.Dtos.UserEducationDtos;
using CvProject.ENTITY.Dtos.UserCertificateDtos;
using CvProject.ENTITY.Dtos.UserLanguageDtos;
using CvProject.ENTITY.Dtos.UserInterestDtos;
using Microsoft.AspNetCore.Authorization;
using CvProject.DAL.Abstract;
using System.IO;
using NuGet.Packaging.Signing;
using AspNetCoreHero.ToastNotification.Abstractions;
using CvProject.BLL.Contants;

namespace CvProject.MVC.Controllers
{
    [Authorize]
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
        private readonly IUserInterestService _interestService;
        private readonly IUserDal _userDal;
        private readonly INotyfService _notyf;

        public AdminController(IAdminAccountService adminAccountService, IAuthService authService, IUserSocialMediaService userSocialMediaService, IUserExperienceService experienceService, IUserReferenceService userReferenceService, IUserSkillService skillService, IUserEducationService educationService, IUserCertificateService certificateService, IUserLanguageService languageService, IUserInterestService interestService, IUserDal userDal, INotyfService notyfService)
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
            _interestService = interestService;
            _userDal = userDal;
            _notyf = notyfService;
        }
        public int GetUserId()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            return Convert.ToInt32(userId);
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
            dto.UserId = GetUserId();
            var result = _authService.UserPasswordChange(dto);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminAccount", "Admin");
        }

        [HttpGet]
        public IActionResult AdminAccount()
        {
            var userId = GetUserId();
            var result = _adminAccountService.GetAdminAccount(userId).Data;
            return View(result);
        }

        [HttpPost]
        public IActionResult AdminAccount(UpdateAdminAccountDto dto)
        {
            dto.UserId = GetUserId();
            var result = _adminAccountService.UpdateAdminAccount(dto);
            ViewBag.Message = result.MessageCode;
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminAccount", "Admin");
        }

        [HttpGet]
        public IActionResult AdminSocialMedia()
        {
            var userId = GetUserId();
            var result = _userSocialMediaService.GetUserSocialMedia(userId).Data;
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
            dto.UserId = GetUserId();
            dto.SocialMediaIcon = "fab fa-" + dto.SocialMediaName.ToLower();
            if (dto.SocialMediaIcon== "fab fa-ınstagram")
            {
                dto.SocialMediaIcon = "fab fa-instagram";
            }
            var result = _userSocialMediaService.AddSocialMedia(dto);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminSocialMedia", "Admin");
        }

        [HttpGet]
        public IActionResult DeleteSocialMedia(int id)
        {
            var result = _userSocialMediaService.DeleteSocialMedia(id);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminSocialMedia", "Admin");
        }

        [HttpGet]
        public IActionResult AdminExperience()
        {
            var userId = GetUserId();
            var result = _experienceService.GetUserExperience(userId).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteExperience(int id)
        {
            var result = _experienceService.DeleteExperience(id);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
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
            dto.UserId = GetUserId(); ;
            var result = _experienceService.AddExperiece(dto);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
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
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminExperience", "Admin");
        }

        [HttpGet]
        public IActionResult AdminReference()
        {
            var userId = GetUserId();
            var result = _userReferenceService.GetUserReference(userId).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteReference(int id)
        {
            var result = _userReferenceService.DeleteReference(id);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
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
            dto.UserId = GetUserId();
            var result = _userReferenceService.AddReference(dto);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminReference", "Admin");
        }

        [HttpGet]
        public IActionResult AdminSkill()
        {
            var userId = GetUserId();
            var result = _skillService.GetUserSkill(userId).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteSkill(int id)
        {
            var result = _skillService.DeleteSkill(id);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
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
            dto.UserId = GetUserId();
            var result = _skillService.AddSkill(dto);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminSkill", "Admin");
        }

        [HttpGet]
        public IActionResult AdminEducation()
        {
            var userId = GetUserId();
            var result = _educationService.GetUserEducation(userId).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteEducation(int id)
        {
            var result = _educationService.DeleteEducation(id);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
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
            dto.UserId = GetUserId();
            var result = _educationService.AddEducation(dto);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
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
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminEducation", "Admin");
        }

        [HttpGet]
        public IActionResult AdminCertificate()
        {
            var userId = GetUserId();
            var result = _certificateService.GetUserCertificate(userId).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteCertificate(int id)
        {
            var result = _certificateService.DeleteUserCertificate(id);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
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
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
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
            dto.UserId = GetUserId();
            var result = _certificateService.AddCertificate(dto);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminCertificate", "Admin");
        }

        [HttpGet]
        public IActionResult AdminLanguage()
        {
            var userId = GetUserId();
            var result = _languageService.GetUserLanguage(userId).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteLanguage(int id)
        {
            var result = _languageService.DeleteUserLanguage(id);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
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
            dto.UserId = GetUserId();
            var result = _languageService.AddUserLanguage(dto);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminLanguage", "Admin");
        }

        [HttpGet]
        public IActionResult AdminInterest()
        {
            var userId = GetUserId();
            var result = _interestService.GetUserInterest(userId).Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteInterest(int id)
        {
            var result = _interestService.DeleteInterest(id);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminInterest", "Admin");

        }
        [HttpPost]
        public IActionResult AdminInterest(AddUserInterestDto dto)//addInterest
        {
            dto.UserId = GetUserId();
            var result = _interestService.AddInterest(dto);
            if (result.MessageCode == Messages.success)
            {
                _notyf.Success(result.Message);
            }
            else
            {
                _notyf.Error(result.MessageCode);
            }
            return RedirectToAction("AdminInterest", "Admin");
        }

        [HttpGet]
        public async Task<FileStreamResult> CreatePdf()
        {
            var userId = GetUserId();
            var create = _adminAccountService.CreatePdf(userId);

            var path = $"wwwroot/UserPdfFiles/{create.Message}.pdf";
            var stream = System.IO.File.OpenRead(path);

            var download = _adminAccountService.DownloadPdf(userId);
            _notyf.Success("Pdf file downloaded successfully.");
            return new FileStreamResult(stream, "application/pdf");
        }
    }
}

