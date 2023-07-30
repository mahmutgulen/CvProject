using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserEducationDtos
{
    public class UpdateUserEducationDto : IDto
    {
        public int Id { get; set; }
        public string EducationName { get; set; }
        public string EducationBranch { get; set; }
        public string EducationCountry { get; set; }
        public string EducationCity { get; set; }
        public DateTime EducationStartDate { get; set; }
        public DateTime EducationEndDate { get; set; }
    }
}
