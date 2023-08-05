using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.UserDtos;
using System.Globalization;

namespace CvProject.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUserAddressDal _userAddressDal;

        public UserManager(IUserDal userDal, IUserAddressDal userAddressDal)
        {
            _userDal = userDal;
            _userAddressDal = userAddressDal;
        }

        public IDataResult<GetUserDto> GetUser(int userId)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == userId);
                var userAddress = _userAddressDal.Get(x => x.UserId == userId);

                var dto = new GetUserDto
                {
                    UserFirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.UserFirstName),
                    UserSurname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.UserSurname),
                    UserMail = user.UserMail,
                    UserPhoneNumber = user.UserPhoneNumber,
                    UserImage = user.UserImage,
                    UserCountry = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userAddress.UserCountry),
                    UserCity = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userAddress.UserCity)
                };

                return new SuccessDataResult<GetUserDto>(dto, "ok", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GetUserDto>(new GetUserDto(), e.Message, Messages.unk_err);
            }
        }
    }
}
