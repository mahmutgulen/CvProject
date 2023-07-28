using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserReferenceDtos
{
    public class GetUserReferenceDto : IDto
    {
        public string ReferenceCompany { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceSurname { get; set; }
        public string ReferencePhoneNumber { get; set; }
        public string ReferenceMail { get; set; }
    }
}
