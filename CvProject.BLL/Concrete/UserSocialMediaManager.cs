using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.UserSocialMediaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class UserSocialMediaManager : IUserSocialMediaService
    {
        private readonly IUserSocialMediaDal _userSocialMediaDal;

        public UserSocialMediaManager(IUserSocialMediaDal userSocialMediaDal)
        {
            _userSocialMediaDal = userSocialMediaDal;
        }

        public IDataResult<List<GetUserSocialMediaDto>> GetUserSocialMedia(int userId)
        {
            try
            {
                var userSocialMedias = _userSocialMediaDal.GetAll(x => x.UserId == userId).ToList();

                if (userSocialMedias.Count == 0 || userSocialMedias == null)
                {
                    return new ErrorDataResult<List<GetUserSocialMediaDto>>(new List<GetUserSocialMediaDto>(), "not found", Messages.not_found);
                }
                var list = new List<GetUserSocialMediaDto>();

                foreach (var item in userSocialMedias)
                {
                    list.Add(new GetUserSocialMediaDto
                    {
                        SocialMediaIcon = item.SocialMediaIcon,
                        SocialMediaLink = item.SocialMediaLink,
                        SocialMediaName = item.SocialMediaName
                    });
                }

                return new SuccessDataResult<List<GetUserSocialMediaDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GetUserSocialMediaDto>>(new List<GetUserSocialMediaDto>(), e.Message, Messages.unk_err);
            }
        }
    }
}
