using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Concrete
{
    public class UserSocialMedia : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaIcon { get; set; }
        public string SocialMediaLink { get; set; }
        public bool SocialMediaStatus { get; set; }
    }
}
