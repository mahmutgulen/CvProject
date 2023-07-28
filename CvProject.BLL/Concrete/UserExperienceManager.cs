using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.DAL.Concrete;
using CvProject.ENTITY.Dtos.UserExperienceDtos;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class UserExperienceManager : IUserExperienceService
    {
        private readonly IUserExperienceDal _userExperienceDal;

        public UserExperienceManager(IUserExperienceDal userExperienceDal)
        {
            _userExperienceDal = userExperienceDal;
        }

        public IDataResult<List<GetUserExperienceDto>> GetUserExperience(int userId)
        {
            try
            {
                var userExperiences = _userExperienceDal.GetAll(x => x.UserId == userId);

                if (userExperiences == null || userExperiences.Count == 0)
                {
                    return new ErrorDataResult<List<GetUserExperienceDto>>(new List<GetUserExperienceDto>(), "not_found", Messages.not_found);
                }

                var list = new List<GetUserExperienceDto>();

                foreach (var item in userExperiences)
                {
                    list.Add(new GetUserExperienceDto
                    {
                        CompanyCity = item.CompanyCity,
                        CompanyCountry = item.CompanyCountry,
                        CompanyName = item.CompanyName,
                        Description = item.Description,
                        ExperienceEndDate = item.ExperienceEndDate,
                        ExperienceStartDate = item.ExperienceStartDate,
                        Position = item.Position
                    });
                }

                return new SuccessDataResult<List<GetUserExperienceDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GetUserExperienceDto>>(new List<GetUserExperienceDto>(), e.Message, Messages.unk_err);
            }
        }
    }
}
