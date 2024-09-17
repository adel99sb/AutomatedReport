using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class Teacher
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(50)]
        public string Full_Name { get; set; }        
        [StringLength(16)]
        public string? Phone { get; set; }
    }
}
