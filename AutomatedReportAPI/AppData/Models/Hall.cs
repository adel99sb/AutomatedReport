using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class Hall
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
    }
}
