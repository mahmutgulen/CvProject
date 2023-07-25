using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserAddressDtos;

namespace CvProject.BLL.Abstract
{
    public interface IUserAddressService
    {
        IDataResult<bool> AddUserAdress(AddUserAddressDto dto);
        IDataResult<GetUserAddressDto> GetUserAddress(int id);
        IDataResult<bool> UpdateUserAddress(UpdateUserAddressDto dto);

    }
}
