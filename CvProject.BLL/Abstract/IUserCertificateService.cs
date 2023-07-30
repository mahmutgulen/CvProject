using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserCertificateDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserCertificateService
    {
        IDataResult<List<GetUserCertificateDto>> GetUserCertificate(int userId);
        IDataResult<bool> AddCertificate(AddUserCertificateDto dto);
        IDataResult<bool> UpdateCertificate(UpdateUserCertifiacateDto dto);
        IDataResult<GetUserCertificateDto> GetByIdUserCertificate(int id);
        IDataResult<bool> DeleteUserCertificate(int id);
    }
}
