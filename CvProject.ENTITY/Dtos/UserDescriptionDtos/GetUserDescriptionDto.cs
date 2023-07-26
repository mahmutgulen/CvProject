using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserDescriptionDtos
{
    public class GetUserDescriptionDto : IDto
    {
        public string UserDescriptionText { get; set; }
    }
}
