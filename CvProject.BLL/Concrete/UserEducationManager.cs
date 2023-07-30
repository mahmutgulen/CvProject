using Azure.Messaging;
using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Concrete;
using CvProject.ENTITY.Dtos.UserEducationDtos;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class UserEducationManager : IUserEducationService
    {
        private readonly IUserEducationDal _userEducationDal;

        public UserEducationManager(IUserEducationDal userEducationDal)
        {
            _userEducationDal = userEducationDal;
        }

        public IDataResult<bool> AddEducation(AddUserEducationDto dto)
        {
            try
            {
                var newEducation = new UserEducation
                {
                    EducationBranch = dto.EducationBranch,
                    EducationCity = dto.EducationCity,
                    EducationCountry = dto.EducationCountry,
                    EducationEndDate = dto.EducationEndDate,
                    EducationName = dto.EducationName,
                    EducationStartDate = dto.EducationStartDate,
                    EducationStatus = true,
                    UserId = dto.UserId
                };
                _userEducationDal.Add(newEducation);

                return new SuccessDataResult<bool>(true, "added_education", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> DeleteEducation(int id)
        {
            try
            {
                var item = _userEducationDal.Get(x => x.Id == id);

                _userEducationDal.Delete(item);
                return new SuccessDataResult<bool>(true, "education_deleted", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<GetUserEducationDto> GetByIdUserEducation(int id)
        {
            try
            {
                var education = _userEducationDal.Get(x => x.Id == id);

                var dto = new GetUserEducationDto
                {
                    EducationStartDate = education.EducationStartDate,
                    EducationBranch = education.EducationBranch,
                    EducationCity = education.EducationCity,
                    EducationCountry = education.EducationCountry,
                    EducationEndDate = education.EducationEndDate,
                    EducationName = education.EducationName,
                    Id = education.Id
                };


                return new SuccessDataResult<GetUserEducationDto>(dto, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GetUserEducationDto>(new GetUserEducationDto(), e.Message, Messages.unk_err);
            }
        }

        public IDataResult<List<GetUserEducationDto>> GetUserEducation(int userId)
        {
            try
            {
                var userEducations = _userEducationDal.GetAll(x => x.UserId == userId);

                if (userEducations.Count == 0)
                {
                    return new ErrorDataResult<List<GetUserEducationDto>>(new List<GetUserEducationDto>(), "not_found", Messages.not_found);
                }

                var list = new List<GetUserEducationDto>();

                foreach (var item in userEducations)
                {
                    list.Add(new GetUserEducationDto
                    {
                        EducationBranch = item.EducationBranch,
                        EducationCity = item.EducationCity,
                        EducationCountry = item.EducationCountry,
                        EducationEndDate = item.EducationEndDate,
                        EducationName = item.EducationName,
                        EducationStartDate = item.EducationStartDate,
                        Id = item.Id
                    });
                }

                return new SuccessDataResult<List<GetUserEducationDto>>(list, "success", Messages.success);

            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<GetUserEducationDto>>(new List<GetUserEducationDto>(), e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> UpdateEducation(UpdateUserEducationDto dto)
        {
            try
            {
                var item = _userEducationDal.Get(x => x.Id == dto.Id);
                item.EducationCity = dto.EducationCity;
                item.EducationCountry = dto.EducationCountry;
                item.EducationName = dto.EducationName;
                item.EducationBranch = dto.EducationBranch;
                item.EducationEndDate = dto.EducationEndDate;
                item.EducationStartDate = dto.EducationStartDate;
                _userEducationDal.Update(item);

                return new SuccessDataResult<bool>(true, "success", Messages.success);

            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }
    }
}
