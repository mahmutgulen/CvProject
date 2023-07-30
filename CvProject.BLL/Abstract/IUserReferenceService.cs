using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserReferenceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserReferenceService
    {
        IDataResult<List<GetUserReferenceDto>> GetUserReference(int userId);

        IDataResult<bool> AddReference(AddUserReferenceDto dto);
        IDataResult<bool> DeleteReference(int id);
    }
}
