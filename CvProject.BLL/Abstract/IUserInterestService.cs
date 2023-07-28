using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserInterestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserInterestService
    {
        IDataResult<List<GetUserInterestDto>> GetUserInterest(int userId);
    }
}
