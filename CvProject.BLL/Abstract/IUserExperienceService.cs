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
        IDataResult<bool> DeleteExperience(int itemId);

        IDataResult<bool> UpdateExperiece(UpdateExperienceDto dto);
        IDataResult<bool> AddExperiece(AddExperienceDto dto);

        IDataResult<GetUserExperienceDto> GetByIdExperience(int id);
    }
}
