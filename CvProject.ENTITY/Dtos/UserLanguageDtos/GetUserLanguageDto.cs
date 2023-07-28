using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserLanguageDtos
{
    public class GetUserLanguageDto : IDto
    {
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
    }
}
