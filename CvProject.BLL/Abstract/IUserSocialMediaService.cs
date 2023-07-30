using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserSocialMediaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserSocialMediaService
    {
        IDataResult<List<GetUserSocialMediaDto>> GetUserSocialMedia(int userId);
        IDataResult<bool> AddSocialMedia(AddSocialMediaDto dto);
        IDataResult<bool> DeleteSocialMedia(int itemId);
    }
}
