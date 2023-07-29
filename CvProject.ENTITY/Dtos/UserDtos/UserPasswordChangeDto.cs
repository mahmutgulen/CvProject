using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserDtos
{
    public class UserPasswordChangeDto : IDto
    {
        public int UserId { get; set; }
        public string UserOldPassword { get; set; }
        public string UserNewPassword { get; set; }
        public string UserConfirmPassword { get; set; }
    }
}
