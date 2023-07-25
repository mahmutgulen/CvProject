using CvProject.BLL.Abstract;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.UserAddressDtos;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.API.Controllers
{
    public class AddressController : Controller
    {
        private readonly IUserAddressService _userAddressService;

        public AddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }

        [HttpGet("getuseraddress")]
        public IActionResult GetUserAddress(int id)
        {
            var result = _userAddressService.GetUserAddress(id);
            return Ok(result);
        }

        [HttpPost("adduseraddress")]
        public IActionResult AddUserAddress(AddUserAddressDto dto)
        {
            var result = _userAddressService.AddUserAdress(dto);
            return Ok(result);
        }

        [HttpPost("updateuseraddress")]
        public IActionResult UpdateUserAddress(UpdateUserAddressDto dto)
        {
            var result = _userAddressService.UpdateUserAddress(dto);
            return Ok(result);
        }
    }
}
