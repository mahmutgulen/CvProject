using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserDescriptionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserDescriptionService
    {
        IDataResult<GetUserDescriptionDto> GetUserDescription(int userId);
    }
}
