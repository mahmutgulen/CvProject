using Azure.Identity;
using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Entities.Concrete;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.AdminAccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class AdminAccountManager : IAdminAccountService
    {
        private readonly IUserDal _userDal;
        private readonly IUserDescriptionDal _userDescriptionDal;
        private readonly IUserAddressDal _userAddressDal;

        public AdminAccountManager(IUserDal userDal, IUserDescriptionDal userDescriptionDal, IUserAddressDal userAddressDal)
        {
            _userDal = userDal;
            _userDescriptionDal = userDescriptionDal;
            _userAddressDal = userAddressDal;
        }

        public IDataResult<GetAdminAccountDto> GetAdminAccount(int userId)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == userId);
                var address = _userAddressDal.Get(x => x.UserId == userId);
                var description = _userDescriptionDal.Get(x => x.UserId == userId);

                var dto = new GetAdminAccountDto
                {
                    UserCity = address.UserCity,
                    UserCountry = address.UserCountry,
                    UserDescription = description.UserDescriptionText,
                    UserFirstName = user.UserFirstName,
                    UserImage = user.UserImage,
                    UserMail = user.UserMail,
                    UserName = user.UserName,
                    UserPhoneNumber = user.UserPhoneNumber,
                    UserSurname = user.UserSurname
                };

                return new SuccessDataResult<GetAdminAccountDto>(dto, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GetAdminAccountDto>(new GetAdminAccountDto(), e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> UpdateAdminAccount(GetAdminAccountDto dto)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == dto.UserId);
                
                var address = _userAddressDal.Get(x => x.UserId == dto.UserId);
                var description = _userDescriptionDal.Get(x => x.UserId == dto.UserId);
                user.UserName = user.UserName;
                user.UserPhoneNumber = dto.UserPhoneNumber;
                user.UserSurname = dto.UserSurname;
                user.UserMail = dto.UserMail;
                user.UserFirstName = dto.UserFirstName;
                user.UserImage = dto.UserImage;
                address.UserCity = dto.UserCity;
                address.UserCountry = dto.UserCountry;
                description.UserDescriptionText = dto.UserDescription;

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
