using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
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
                        LanguageName = item.LanguageName
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
