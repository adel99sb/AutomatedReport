using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class _Class
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string From_Time { get; set; }
        [Required]
        public string To_Time { get; set; }
    }
}
