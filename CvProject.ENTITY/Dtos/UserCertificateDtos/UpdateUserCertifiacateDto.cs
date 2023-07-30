using CvProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.ENTITY.Dtos.UserCertificateDtos
{
    public class UpdateUserCertifiacateDto : IDto
    {
        public int Id { get; set; }
        public DateTime CertificateDate { get; set; }
        public string CertificateProvider { get; set; }
        public string CertificateName { get; set; }
        public string CertificateCountry { get; set; }
        public string CertificateCity { get; set; }
    }
}
