using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserSocialMediaDtos
{
    public class AddSocialMediaDto : IDto
    {
        public int UserId { get; set; }
        public string? SocialMediaName { get; set; }
        public string? SocialMediaIcon { get; set; }
        public string? SocialMediaLink { get; set; }
    }
}
