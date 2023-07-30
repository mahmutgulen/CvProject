using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Concrete;
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

        public IDataResult<bool> AddReference(AddUserReferenceDto dto)
        {
            try
            {
                var check = _userReferenceDal.Get(x => x.ReferenceMail == dto.ReferenceMail && x.UserId == dto.UserId);

                if (check != null)
                {
                    return new ErrorDataResult<bool>(false, "reference_already_exists", Messages.reference_already_exists);
                }

                var newReference = new UserReference
                {
                    ReferenceCompany = dto.ReferenceCompany,
                    ReferenceMail = dto.ReferenceMail,
                    ReferenceName = dto.ReferenceName,
                    ReferencePhoneNumber = dto.ReferencePhoneNumber,
                    ReferenceStatus = true,
                    ReferenceSurname = dto.ReferenceSurname,
                    UserId = dto.UserId
                };
                _userReferenceDal.Add(newReference);

                return new SuccessDataResult<bool>(true, "referene_added", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> DeleteReference(int id)
        {
            try
            {
                var item = _userReferenceDal.Get(x => x.Id == id);

                _userReferenceDal.Delete(item);

                return new SuccessDataResult<bool>(true, "deleted_reference", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
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
                        Id = item.Id,
                        ReferenceSurname = item.ReferenceSurname,
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
