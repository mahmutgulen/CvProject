using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserExperienceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserExperienceService
    {
        IDataResult<List<GetUserExperienceDto>> GetUserExperience(int userId);
    }
}
