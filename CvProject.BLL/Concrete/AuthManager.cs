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
