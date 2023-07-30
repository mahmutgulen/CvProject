using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Concrete;
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

        public IDataResult<bool> AddSocialMedia(AddSocialMediaDto dto)
        {
            try
            {
                var checkUserSocialMedia = _userSocialMediaDal.GetAll(x => x.UserId == dto.UserId && x.SocialMediaStatus == true);
                //4 adetten fazla link ekleyememeli
                if (checkUserSocialMedia.Count >= 4)
                {
                    return new ErrorDataResult<bool>(false, "maximum_of_4_social_media_can_be_added", Messages.maximum_of_4_social_media_can_be_added);
                }
                //aynı linkten ekleyememeli
                foreach (var item in checkUserSocialMedia)
                {
                    if (item.SocialMediaName == dto.SocialMediaName)
                    {
                        return new ErrorDataResult<bool>(false, "social_media_already_exists", Messages.social_media_already_exists);
                    }
                }

                var socialMedia = new UserSocialMedia
                {
                    SocialMediaIcon = dto.SocialMediaIcon,
                    SocialMediaLink = dto.SocialMediaLink,
                    SocialMediaName = dto.SocialMediaName,
                    SocialMediaStatus = true,
                    UserId = dto.UserId
                };

                _userSocialMediaDal.Add(socialMedia);

                return new SuccessDataResult<bool>(true, "social_media_added", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> DeleteSocialMedia(int itemId)
        {
            try
            {
                var item = _userSocialMediaDal.Get(x => x.Id == itemId);

                item.SocialMediaStatus = false;
                _userSocialMediaDal.Update(item);

                return new SuccessDataResult<bool>(true, "item_deleted", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<List<GetUserSocialMediaDto>> GetUserSocialMedia(int userId)
        {
            try
            {
                var userSocialMedias = _userSocialMediaDal.GetAll(x => x.UserId == userId && x.SocialMediaStatus == true).ToList();

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
                        SocialMediaName = item.SocialMediaName,
                        Id = item.Id,
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
