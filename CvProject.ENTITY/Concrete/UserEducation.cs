using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Concrete
{
    public class UserEducation : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EducationName { get; set; }
        public string EducationBranch { get; set; }
        public string EducationCountry { get; set; }
        public string EducationCity { get; set; }
        public DateTime EducationStartDate { get; set; }
        public DateTime EducationEndDate { get; set; }
        public bool EducationStatus { get; set; }
    }
}
