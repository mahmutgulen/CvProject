using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Concrete
{
    public class UserDescription : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserDescriptionText { get; set; }
        public bool UserStatus { get; set; }
    }
}
