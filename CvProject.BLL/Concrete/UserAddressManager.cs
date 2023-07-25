using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Entities;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Concrete;
using CvProject.ENTITY.Dtos.UserAddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class UserAddressManager : IUserAddressService
    {
        private readonly IUserAddressDal _userAddressDal;

        public UserAddressManager(IUserAddressDal userAddressDal)
        {
            _userAddressDal = userAddressDal;
        }

        public IDataResult<bool> AddUserAdress(AddUserAddressDto dto)
        {
            try
            {
                var address = new UserAddress
                {
                    UserAddressStatus = true,
                    UserCity = dto.UserCity,
                    UserCountry = dto.UserCountry,
                    UserDistrict = dto.UserDistrict,
                    UserId = dto.UserId,
                };
                _userAddressDal.Add(address);

                return new SuccessDataResult<bool>(true, "address_added", Messages.address_added);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<GetUserAddressDto> GetUserAddress(int id)
        {
            try
            {
                var address = _userAddressDal.Get(x => x.Id == id);

                var dto = new GetUserAddressDto
                {
                    Id = address.Id,
                    UserAddressStatus = address.UserAddressStatus,
                    UserCity = address.UserCity,
                    UserCountry = address.UserCountry,
                    UserDistrict = address.UserDistrict,
                    UserId = address.UserId
                };

                return new SuccessDataResult<GetUserAddressDto>(dto, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new SuccessDataResult<GetUserAddressDto>(new GetUserAddressDto(), e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> UpdateUserAddress(UpdateUserAddressDto dto)
        {
            try
            {
                var address = _userAddressDal.Get(x => x.Id == dto.Id);

                address.UserCity = dto.UserCity;
                address.UserDistrict = dto.UserDistrict;
                address.UserCountry = dto.UserCountry;
                _userAddressDal.Update(address);

                return new SuccessDataResult<bool>(true, "address_updated", Messages.address_updated);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }
    }
}
