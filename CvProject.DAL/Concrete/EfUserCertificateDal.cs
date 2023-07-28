using CvProject.CORE.DataAccess.EntityFramework;
using CvProject.DAL.Abstract;
using CvProject.DAL.Concrete.EntityFramework;
using CvProject.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.DAL.Concrete
{
    public class EfUserCertificateDal : EfEntityRepositoryBase<UserCertificate, CvCreatorContext>, IUserCertificateDal
    {
    }
}
