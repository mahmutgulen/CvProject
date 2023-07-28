using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.UserReferenceDtos;

namespace CvProject.BLL.Concrete
{
    public class UserReferenceManager : IUserReferenceService
    {
        private readonly IUserReferenceDal _userReferenceDal;

        public UserReferenceManager(IUserReferenceDal userReferenceDal)
        {
            _userReferenceDal = userReferenceDal;
        }

        public IDataResult<List<GetUserReferenceDto>> GetUserReference(int userId)
        {
            try
            {
                var userReferences = _userReferenceDal.GetAll(x => x.UserId == userId);

                if (userReferences.Count == 0)
                {
                    return new ErrorDataResult<List<GetUserReferenceDto>>(new List<GetUserReferenceDto>(), "not_found", Messages.not_found);
                }

                var list = new List<GetUserReferenceDto>();

                foreach (var item in userReferences)
                {
                    list.Add(new GetUserReferenceDto
                    {
                        ReferenceCompany = item.ReferenceCompany,
                        ReferenceMail = item.ReferenceMail,
                        ReferenceName = item.ReferenceName,
                        ReferencePhoneNumber = item.ReferencePhoneNumber,
                        ReferenceSurname = item.ReferenceSurname
                    });
                }
                return new SuccessDataResult<List<GetUserReferenceDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GetUserReferenceDto>>(new List<GetUserReferenceDto>(), e.Message, Messages.unk_err);
            }
        }
    }
}
