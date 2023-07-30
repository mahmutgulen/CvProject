using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Concrete;
using CvProject.ENTITY.Dtos.UserLanguageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class UserLanguageManager : IUserLanguageService
    {
        private readonly IUserLanguageDal _userLanguageDal;

        public UserLanguageManager(IUserLanguageDal userLanguageDal)
        {
            _userLanguageDal = userLanguageDal;
        }

        public IDataResult<bool> AddUserLanguage(AddUserLanguageDto dto)
        {
            try
            {
                var check = _userLanguageDal.Get(x => x.LanguageName == dto.LanguageName && x.UserId == dto.UserId);
                if (check != null)
                {
                    return new ErrorDataResult<bool>(false, "language_already_exits", Messages.language_already_exits);
                }

                var newLanguage = new UserLanguage
                {
                    LanguageLevel = dto.LanguageLevel,
                    LanguageName = dto.LanguageName,
                    LanguageStatus = true,
                    UserId = dto.UserId,
                };
                _userLanguageDal.Add(newLanguage);
                return new SuccessDataResult<bool>(true, "language_added", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> DeleteUserLanguage(int id)
        {
            try
            {
                var item = _userLanguageDal.Get(x => x.Id == id);
                _userLanguageDal.Delete(item);
                return new SuccessDataResult<bool>(true, "language_deleted", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<List<GetUserLanguageDto>> GetUserLanguage(int userId)
        {
            try
            {
                var userLanguages = _userLanguageDal.GetAll(x => x.UserId == userId);
                if (userLanguages.Count == 0)
                {
                    return new ErrorDataResult<List<GetUserLanguageDto>>(new List<GetUserLanguageDto>(), "not_found", Messages.not_found);
                }

                var list = new List<GetUserLanguageDto>();

                foreach (var item in userLanguages)
                {
                    list.Add(new GetUserLanguageDto
                    {
                        LanguageLevel = item.LanguageLevel,
                        LanguageName = item.LanguageName,
                        Id = item.Id
                    });
                }

                return new SuccessDataResult<List<GetUserLanguageDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GetUserLanguageDto>>(new List<GetUserLanguageDto>(), e.Message, Messages.unk_err);
            }
        }
    }
}
