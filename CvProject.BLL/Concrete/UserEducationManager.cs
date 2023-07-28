using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.UserEducationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        EducationStartDate = item.EducationStartDate
                    });
                }

                return new SuccessDataResult<List<GetUserEducationDto>>(list, "success", Messages.success);

            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<GetUserEducationDto>>(new List<GetUserEducationDto>(), e.Message, Messages.unk_err);
            }
        }
    }
}
