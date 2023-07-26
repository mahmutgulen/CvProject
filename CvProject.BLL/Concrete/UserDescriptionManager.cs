using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.UserDescriptionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class UserDescriptionManager : IUserDescriptionService
    {
        private readonly IUserDescriptionDal _userDescriptionDal;

        public UserDescriptionManager(IUserDescriptionDal userDescriptionDal)
        {
            _userDescriptionDal = userDescriptionDal;
        }

        public IDataResult<GetUserDescriptionDto> GetUserDescription(int userId)
        {
            try
            {
                var userDescription = _userDescriptionDal.Get(x => x.UserId == userId);
                if (userDescription == null)
                {
                    return new ErrorDataResult<GetUserDescriptionDto>(new GetUserDescriptionDto(), "not_found", Messages.not_found);
                }

                var dto = new GetUserDescriptionDto
                {
                    UserDescriptionText = userDescription.UserDescriptionText
                };

                return new SuccessDataResult<GetUserDescriptionDto>(dto, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GetUserDescriptionDto>(new GetUserDescriptionDto(), e.Message, Messages.unk_err);
            }
        }
    }
}
