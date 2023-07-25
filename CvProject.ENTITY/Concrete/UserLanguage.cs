using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Concrete
{
    public class UserLanguage : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
        public bool LanguageStatus { get; set; }
    }
}
