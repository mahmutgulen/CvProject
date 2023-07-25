using CvProject.CORE.DataAccess.EntityFramework;
using CvProject.CORE.Entities.Concrete;

namespace CvProject.DAL.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
