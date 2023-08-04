using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserDtos
{
    public class UserRegisterDto : IDto
    {
        
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserConfirmPassword { get; set; }
    }
}
