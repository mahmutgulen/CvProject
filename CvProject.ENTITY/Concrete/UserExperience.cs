﻿using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Concrete
{
    public class UserExperience : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyCity { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public DateTime ExperienceStartDate { get; set; }
        public DateTime ExperienceEndDate { get; set; }
        public bool UserExperienceStatus { get; set; }
    }
}
