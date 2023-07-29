using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Entities.Concrete;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;

        public AuthManager(IUserDal userDal)
        {
            _userDal = userDal;
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
                var existsCheck = _userDal.Get(x => x.UserMail == dto.UserMail || x.UserPhoneNumber == dto.UserPhoneNumber);
                if (existsCheck != null)
                {
                    return new ErrorDataResult<bool>(false, "mail_and_phonenumber_exists", Messages.mail_and_phonenumber_exists);
                }

                if (dto.UserPassword != dto.UserConfirmPassword)
                {
                    return new ErrorDataResult<bool>(false, "password_must_be_same", Messages.password_must_be_same);
                }


                var userAdd = new User
                {
                    UserMail = dto.UserMail,
                    UserName = dto.UserName,
                    UserPassword = dto.UserPassword,
                    UserPhoneNumber = dto.UserPhoneNumber,
                    UserSurname = dto.UserSurname,
                    UserStatus = true,
                    UserImage = null
                };
                _userDal.Add(userAdd);

                return new SuccessDataResult<bool>(true, "registered_successfully", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }
    }
}
