using CvProject.CORE.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.AdminAccountDtos
{
    public class UpdateAdminAccountDto : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserDescription { get; set; }
        public IFormFile? UserImage { get; set; }
        public string UserFirstName { get; set; }
        public string UserSurname { get; set; }
        public string UserMail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserCountry { get; set; }
        public string UserCity { get; set; }
    }
}
