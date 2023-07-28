using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserDtos
{
    public class GetUserDto:IDto
    {
        public string UserFirstName { get; set; }
        public string UserSurname { get; set; }
        public string UserMail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserCountry { get; set; }
        public string UserCity { get; set; }
        public string? UserImage { get; set; }
    }
}
