using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class Test
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double TotalMark { get; set; }
        [Required]
        public bool IsDone { get; set; }
        public Guid SubjectId { get; set; }
        public Guid DivisionId { get; set; }
        public Subject Subject { get; set; }
        public Division Division { get; set; }
    }
}
