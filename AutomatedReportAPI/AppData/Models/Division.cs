using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class Division
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public Guid CertificateId { get; set; }
        public Certificate Certificate { get; set; }
    }
}
