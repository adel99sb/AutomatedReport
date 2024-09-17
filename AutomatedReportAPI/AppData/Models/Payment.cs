using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public double Value { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
