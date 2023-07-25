using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserAddressDtos
{
    public class AddUserAddressDto : IDto
    {
        public int UserId { get; set; }
        public string UserCountry { get; set; }
        public string UserCity { get; set; }
        public string UserDistrict { get; set; }
    }
}
