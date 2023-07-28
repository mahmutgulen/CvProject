using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
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
                        CertificateProvider = item.CertificateProvider
                    });
                }
                return new SuccessDataResult<List<GetUserCertificateDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GetUserCertificateDto>>(new List<GetUserCertificateDto>(), e.Message, Messages.unk_err);
            }
        }
    }
}
