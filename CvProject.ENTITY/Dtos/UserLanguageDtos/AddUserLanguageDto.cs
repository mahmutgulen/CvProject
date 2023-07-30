using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserLanguageDtos
{
    public class AddUserLanguageDto : IDto
    {
        public int UserId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
    }
}
