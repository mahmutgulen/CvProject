using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserInterestDtos
{
    public class GetUserInterestDto : IDto
    {
        public string InterestName { get; set; }
    }
}
