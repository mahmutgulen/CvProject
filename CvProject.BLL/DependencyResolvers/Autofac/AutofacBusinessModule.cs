using Autofac;
using CvProject.BLL.Abstract;
using CvProject.BLL.Concrete;
using CvProject.DAL.Abstract;
using CvProject.DAL.Concrete;

namespace CvProject.BLL.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();


            builder.RegisterType<UserAddressManager>().As<IUserAddressService>();
            builder.RegisterType<EfUserAddressDal>().As<IUserAddressDal>();


            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
        }
    }
}
