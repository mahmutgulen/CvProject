using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserService
    {
        IDataResult<GetUserDto> GetUser(int userId);
    }
}
