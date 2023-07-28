using Autofac;
using CvProject.BLL.Abstract;
using CvProject.BLL.Concrete;
using CvProject.DAL.Abstract;
using CvProject.DAL.Concrete;
using CvProject.ENTITY.Concrete;

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

            builder.RegisterType<UserSocialMediaManager>().As<IUserSocialMediaService>();
            builder.RegisterType<EfUserSocialMediaDal>().As<IUserSocialMediaDal>();


            builder.RegisterType<UserDescriptionManager>().As<IUserDescriptionService>();
            builder.RegisterType<EfUserDescriptionDal>().As<IUserDescriptionDal>();

            builder.RegisterType<UserSkillManager>().As<IUserSkillService>();
            builder.RegisterType<EfUserSkillDal>().As<IUserSkillDal>();

            builder.RegisterType<UserExperienceManager>().As<IUserExperienceService>();
            builder.RegisterType<EfUserExperienceDal>().As<IUserExperienceDal>();



        }
    }
}
