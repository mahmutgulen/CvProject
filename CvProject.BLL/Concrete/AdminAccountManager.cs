using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Concrete;
using CvProject.ENTITY.Dtos.AdminAccountDtos;
using System.Globalization;

namespace CvProject.BLL.Concrete
{
    public class AdminAccountManager : IAdminAccountService
    {
        private readonly IUserDal _userDal;
        private readonly IUserDescriptionDal _userDescriptionDal;
        private readonly IUserAddressDal _userAddressDal;
        private readonly IUserPdfDal _userPdfDal;

        public AdminAccountManager(IUserDal userDal, IUserDescriptionDal userDescriptionDal, IUserAddressDal userAddressDal, IUserPdfDal userPdfDal)
        {
            _userDal = userDal;
            _userDescriptionDal = userDescriptionDal;
            _userAddressDal = userAddressDal;
            _userPdfDal = userPdfDal;
        }

        public IDataResult<bool> CreatePdf(int userId)
        {
            try
            {
                //var htmlstring = System.IO.File.ReadAllText("Views/Shared/_CvLayout.cshtml");
                var htmlstring = System.IO.File.ReadAllText("Views/Shared/_AdminLayout.cshtml");

                var htmltoPdfConverter = new NReco.PdfGenerator.HtmlToPdfConverter();

                var pdf = htmltoPdfConverter.GeneratePdf(htmlstring);
                var pdfGuidString = Guid.NewGuid();
                System.IO.File.WriteAllBytes($"wwwroot/UserPdfFiles/{pdfGuidString}.pdf", pdf);

                var userPdf = new UserPdf
                {
                    UserId = userId,
                    UserPdfStatus = true,
                    UserPdfId = pdfGuidString.ToString()
                };
                _userPdfDal.Add(userPdf);

                return new SuccessDataResult<bool>(true, pdfGuidString.ToString(), Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> DownloadPdf(int userId)
        {
            try
            {
                var userPdf = _userPdfDal.Get(x => x.UserId == userId && x.UserPdfStatus == true);

                userPdf.UserPdfStatus = false;

                _userPdfDal.Update(userPdf);

                return new SuccessDataResult<bool>(true);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<GetAdminAccountDto> GetAdminAccount(int userId)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == userId);
                var address = _userAddressDal.Get(x => x.UserId == userId);
                var description = _userDescriptionDal.Get(x => x.UserId == userId);
                if (user == null || address == null || description == null)
                {
                    return new ErrorDataResult<GetAdminAccountDto>(new GetAdminAccountDto(), "not_found", Messages.not_found);
                }
                var dto = new GetAdminAccountDto
                {
                    UserCity = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address.UserCity),
                    UserCountry = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address.UserCountry),
                    UserDescription = description.UserDescriptionText,
                    UserFirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.UserFirstName),
                    UserImage = user.UserImage,
                    UserMail = user.UserMail,
                    UserName = user.UserName,
                    UserPhoneNumber = user.UserPhoneNumber,
                    UserSurname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.UserSurname)
                };

                return new SuccessDataResult<GetAdminAccountDto>(dto, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GetAdminAccountDto>(new GetAdminAccountDto(), e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> UpdateAdminAccount(UpdateAdminAccountDto dto)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == dto.UserId);
                if (user == null)
                {
                    return new ErrorDataResult<bool>(false, "not_found", Messages.not_found);
                }
                var address = _userAddressDal.Get(x => x.UserId == dto.UserId);
                var description = _userDescriptionDal.Get(x => x.UserId == dto.UserId);
                user.UserName = user.UserName;
                user.UserPhoneNumber = dto.UserPhoneNumber;
                user.UserSurname = dto.UserSurname;
                user.UserMail = dto.UserMail;
                user.UserFirstName = dto.UserFirstName;
                address.UserCity = dto.UserCity;
                address.UserCountry = dto.UserCountry;
                description.UserDescriptionText = dto.UserDescription;

                if (dto.UserImage != null)
                {
                    var extension = Path.GetExtension(dto.UserImage.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImageFiles/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    dto.UserImage.CopyTo(stream);
                    user.UserImage = newImageName;
                }

                _userAddressDal.Update(address);
                _userDescriptionDal.Update(description);
                _userDal.Update(user);

                return new SuccessDataResult<bool>(true, "account_updated", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }
    }
}
