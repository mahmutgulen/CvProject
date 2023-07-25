using CvProject.CORE.DataAccess.EntityFramework;
using CvProject.CORE.Entities.Concrete;
using CvProject.DAL.Abstract;
using CvProject.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.DAL.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, CvCreatorContext>, IUserDal
    {
    }
}
