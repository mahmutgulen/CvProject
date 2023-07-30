using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.DAL.Concrete;
using CvProject.ENTITY.Concrete;
using CvProject.ENTITY.Dtos.UserExperienceDtos;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public IDataResult<bool> AddExperiece(AddExperienceDto dto)
        {
            try
            {
                var newExperience = new UserExperience
                {
                    CompanyCity = dto.CompanyCity,
                    CompanyCountry = dto.CompanyCountry,
                    CompanyName = dto.CompanyName,
                    Description = dto.Description,
                    ExperienceEndDate = dto.ExperienceEndDate,
                    ExperienceStartDate = dto.ExperienceStartDate,
                    Position = dto.Position,
                    UserExperienceStatus = true,
                    UserId = dto.UserId
                };

                _userExperienceDal.Add(newExperience);

                return new SuccessDataResult<bool>(true, "experience_added", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> DeleteExperience(int itemId)
        {
            try
            {
                var item = _userExperienceDal.Get(x => x.Id == itemId);

                _userExperienceDal.Delete(item);

                return new SuccessDataResult<bool>(true, "item_deleted", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<GetUserExperienceDto> GetByIdExperience(int id)
        {
            try
            {
                var experience = _userExperienceDal.Get(x => x.Id == id);

                var dto = new GetUserExperienceDto
                {
                    CompanyCity = experience.CompanyCity,
                    CompanyCountry = experience.CompanyCountry,
                    CompanyName = experience.CompanyName,
                    Description = experience.Description,
                    ExperienceEndDate = experience.ExperienceEndDate,
                    ExperienceStartDate = experience.ExperienceStartDate,
                    Id = id,
                    Position = experience.Position
                };

                return new SuccessDataResult<GetUserExperienceDto>(dto, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GetUserExperienceDto>(new GetUserExperienceDto(), e.Message, Messages.unk_err);
            }
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
                        Position = item.Position,
                        Id = item.Id,
                    });
                }

                return new SuccessDataResult<List<GetUserExperienceDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GetUserExperienceDto>>(new List<GetUserExperienceDto>(), e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> UpdateExperiece(UpdateExperienceDto dto)
        {
            try
            {
                var userExperience = _userExperienceDal.Get(x => x.Id == dto.Id);

                userExperience.ExperienceStartDate = dto.ExperienceStartDate;
                userExperience.ExperienceEndDate = dto.ExperienceEndDate;
                userExperience.CompanyCity = dto.CompanyCity;
                userExperience.CompanyCountry = dto.CompanyCountry;
                userExperience.CompanyName = dto.CompanyName;
                userExperience.Description = dto.Description;
                userExperience.Position = dto.Position;

                _userExperienceDal.Update(userExperience);

                return new SuccessDataResult<bool>(true, "experience_updated", Messages.success);

            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }
    }
}
