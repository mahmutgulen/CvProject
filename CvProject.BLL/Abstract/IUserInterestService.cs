using Autofac.Builder;
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
        IDataResult<bool> DeleteInterest(int id);
        IDataResult<bool> AddInterest(AddUserInterestDto dto);
    }
}
