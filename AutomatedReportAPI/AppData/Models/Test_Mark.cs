using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class Test_Mark
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Range(0,5000)]
        public double Mark { get; set; }
        public Guid TestId { get; set; }
        public Guid StudentId { get; set; }
        public Test Test { get; set; }
        public Student Student { get; set; }
    }
}
