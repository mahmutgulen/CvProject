using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.CORE.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserSurname { get; set; }
        public string UserMail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string? UserImage { get; set; }
        public string UserPassword { get; set; }
        public bool UserStatus { get; set; }
    }
}
