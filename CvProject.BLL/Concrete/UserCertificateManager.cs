using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Concrete;
using CvProject.ENTITY.Dtos.UserCertificateDtos;

namespace CvProject.BLL.Concrete
{
    public class UserCertificateManager : IUserCertificateService
    {
        private readonly IUserCertificateDal _userCertificateDal;

        public UserCertificateManager(IUserCertificateDal userCertificateDal)
        {
            _userCertificateDal = userCertificateDal;
        }

        public IDataResult<bool> AddCertificate(AddUserCertificateDto dto)
        {
            try
            {
                var newCertificate = new UserCertificate
                {
                    CertificateCity = dto.CertificateCity,
                    CertificateCountry = dto.CertificateCountry,
                    CertificateDate = dto.CertificateDate,
                    CertificateName = dto.CertificateName,
                    CertificateProvider = dto.CertificateProvider,
                    CertificateStatus = true,
                    UserId = dto.UserId
                };
                _userCertificateDal.Add(newCertificate);

                return new SuccessDataResult<bool>(true, "certificate_added", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.success);
            }
        }

        public IDataResult<bool> DeleteUserCertificate(int id)
        {
            try
            {
                var item = _userCertificateDal.Get(x => x.Id == id);

                _userCertificateDal.Delete(item);

                return new SuccessDataResult<bool>(true, "certificate_deleted", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.success);
            }
        }

        public IDataResult<GetUserCertificateDto> GetByIdUserCertificate(int id)
        {
            try
            {
                var certificate = _userCertificateDal.Get(x => x.Id == id);

                var dto = new GetUserCertificateDto
                {
                    CertificateCity = certificate.CertificateCity,
                    CertificateCountry = certificate.CertificateCountry,
                    CertificateDate = certificate.CertificateDate,
                    CertificateName = certificate.CertificateName,
                    CertificateProvider = certificate.CertificateProvider,
                    Id = certificate.Id
                };

                return new SuccessDataResult<GetUserCertificateDto>(dto, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GetUserCertificateDto>(new GetUserCertificateDto(), e.Message, Messages.success);
            }
        }

        public IDataResult<List<GetUserCertificateDto>> GetUserCertificate(int userId)
        {
            try
            {
                var userCertificates = _userCertificateDal.GetAll(x => x.UserId == userId);
                if (userCertificates.Count == 0)
                {
                    return new ErrorDataResult<List<GetUserCertificateDto>>(new List<GetUserCertificateDto>(), "not_found", Messages.not_found);
                }
                var list = new List<GetUserCertificateDto>();

                foreach (var item in userCertificates)
                {
                    list.Add(new GetUserCertificateDto
                    {
                        CertificateCity = item.CertificateCity,
                        CertificateCountry = item.CertificateCountry,
                        CertificateDate = item.CertificateDate,
                        CertificateName = item.CertificateName,
                        CertificateProvider = item.CertificateProvider,
                        Id = item.Id
                    });
                }
                return new SuccessDataResult<List<GetUserCertificateDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GetUserCertificateDto>>(new List<GetUserCertificateDto>(), e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> UpdateCertificate(UpdateUserCertifiacateDto dto)
        {
            try
            {
                var item = _userCertificateDal.Get(x => x.Id == dto.Id);

                item.CertificateCity = dto.CertificateCity;
                item.CertificateProvider = dto.CertificateProvider;
                item.CertificateDate = dto.CertificateDate;
                item.CertificateCountry = dto.CertificateCountry;
                item.CertificateName = dto.CertificateName;

                _userCertificateDal.Update(item);

                return new SuccessDataResult<bool>(true, "certificate_updated", Messages.success);

            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.success);
            }
        }
    }
}
