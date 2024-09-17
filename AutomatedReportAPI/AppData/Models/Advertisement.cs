using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class Advertisement
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
