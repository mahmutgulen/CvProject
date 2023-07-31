using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Entities.Concrete;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Concrete;
using CvProject.ENTITY.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CvProject.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly IUserAddressDal _addressDal;
        private readonly IUserDescriptionDal _userDescriptionDal;
        public AuthManager(IUserDal userDal, IUserDescriptionDal userDescriptionDal, IUserAddressDal addressDal)
        {
            _userDal = userDal;
            _userDescriptionDal = userDescriptionDal;
            _addressDal = addressDal;
        }

        public IDataResult<bool> UserPasswordChange(UserPasswordChangeDto dto)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == dto.UserId);

                if (user.UserPassword != dto.UserOldPassword)
                {
                    return new ErrorDataResult<bool>(false, "oldpassword_is_wrong", Messages.oldpassword_is_wrong);
                }

                if (user.UserPassword == dto.UserNewPassword)
                {
                    return new ErrorDataResult<bool>(false, "new_password_must_not_be_same_oldpassword", Messages.new_password_must_not_be_same_oldpassword);
                }

                if (dto.UserNewPassword != dto.UserConfirmPassword)
                {
                    return new ErrorDataResult<bool>(false, "passwords_must_be_same", Messages.passwords_must_be_same);
                }

                user.UserPassword = dto.UserNewPassword;
                _userDal.Update(user);
                return new SuccessDataResult<bool>(true, "password_changed", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> UserRegister(UserRegisterDto dto)
        {
            try
            {
                var existsCheck = _userDal.Get(x => x.UserName == dto.UserName);
                if (existsCheck != null)
                {
                    return new ErrorDataResult<bool>(false, "user_name_already_exists", Messages.user_name_already_exists);
                }

                if (dto.UserPassword != dto.UserConfirmPassword)
                {
                    return new ErrorDataResult<bool>(false, "password_must_be_same", Messages.password_must_be_same);
                }

                var newUser = new User
                {
                    UserSurname = "text here",
                    UserPassword = dto.UserPassword,
                    UserFirstName = "text here",
                    UserStatus = true,
                    UserImage = null,
                    UserMail = "text here",
                    UserName = dto.UserName,
                    UserPhoneNumber = "text here"
                };
                _userDal.Add(newUser);

                //Other Actions

                var address = new UserAddress
                {
                    UserAddressStatus = true,
                    UserCity = "text here",
                    UserCountry = "text here",
                    UserDistrict = "text here",
                    UserId = newUser.Id,
                };
                _addressDal.Add(address);

                var desc = new UserDescription
                {
                    UserDescriptionText = "text here",
                    UserId = newUser.Id,
                    UserStatus = true,
                };
                _userDescriptionDal.Add(desc);

                return new SuccessDataResult<bool>(true, "registered_successfully", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }
    }
}
