using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserSkillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserSkillService
    {
        IDataResult<List<GetUserSkillDto>> GetUserSkill(int userId);
    }
}
