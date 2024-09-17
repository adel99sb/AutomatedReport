using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class Subject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public Guid CertificateId { get; set; } // Foreign key property

        public Certificate Certificate { get; set; }
    }
}
