using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Concrete
{
    public class UserCertificate : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CertificateDate { get; set; }
        public string CertificateProvider { get; set; }
        public string CertificateName { get; set; }
        public string CertificateCountry { get; set; }
        public string CertificateCity { get; set; }
        public bool CertificateStatus { get; set; }

    }
}
