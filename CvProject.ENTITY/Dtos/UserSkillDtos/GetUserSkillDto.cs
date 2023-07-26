using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserSkillDtos
{
    public class GetUserSkillDto : IDto
    {
        public string SkillName { get; set; }
        public byte SkillProgress { get; set; }
    }
}
