using CvProject.CORE.DataAccess.EntityFramework;
using CvProject.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.DAL.Abstract
{
    public interface IUserSocialMediaDal : IEntityRepository<UserSocialMedia>
    {
    }
}
