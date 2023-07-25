using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserDtos;

namespace CvProject.BLL.Abstract
{
    public interface IAuthService
    {
        IDataResult<bool> UserRegister(UserRegisterDto dto);
    }
}
