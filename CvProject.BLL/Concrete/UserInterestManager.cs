using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.UserInterestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class UserInterestManager : IUserInterestService
    {
        private readonly IUserInterestDal _userInterestDal;

        public UserInterestManager(IUserInterestDal userInterestDal)
        {
            _userInterestDal = userInterestDal;
        }

        public IDataResult<List<GetUserInterestDto>> GetUserInterest(int userId)
        {
            try
            {
                var userInterests = _userInterestDal.GetAll(x => x.UserId == userId);
                if (userInterests.Count == 0)
                {
                    return new ErrorDataResult<List<GetUserInterestDto>>(new List<GetUserInterestDto>(), "not_found", Messages.not_found);
                }
                var list = new List<GetUserInterestDto>();

                foreach (var item in userInterests)
                {
                    list.Add(new GetUserInterestDto
                    {
                        InterestName = item.InterestName
                    });
                }

                return new SuccessDataResult<List<GetUserInterestDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GetUserInterestDto>>(new List<GetUserInterestDto>(), e.Message, Messages.unk_err);
            }
        }
    }
}
