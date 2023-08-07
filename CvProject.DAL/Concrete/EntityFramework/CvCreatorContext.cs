using CvProject.CORE.Entities.Concrete;
using CvProject.ENTITY.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CvProject.DAL.Concrete.EntityFramework
{
    public class CvCreatorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PH12VSS;Database=CvCreator;User Id=DESKTOP-PH12VSS\mako; integrated security=true; TrustServerCertificate=True;");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserCertificate> UserCertificates { get; set; }
        public DbSet<UserDescription> UserDescriptions { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<UserReference> UserReferences { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<UserSocialMedia> UserSocialMedias { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserPdf> UserPdfs { get; set; }
    }
}
