using CvProject.CORE.DataAccess.EntityFramework;
using CvProject.DAL.Abstract;
using CvProject.DAL.Concrete.EntityFramework;
using CvProject.ENTITY.Concrete;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.DAL.Concrete
{
    public class EfUserEducationDal : EfEntityRepositoryBase<UserEducation, CvCreatorContext>, IUserEducationDal
    {
    }
}
