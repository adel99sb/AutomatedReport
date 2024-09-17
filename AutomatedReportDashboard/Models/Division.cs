using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Division
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CertificateId { get; set; }
        public string CertificateName { get; set; }
        public int? StudentsNumber { get; set; }
    }

}
