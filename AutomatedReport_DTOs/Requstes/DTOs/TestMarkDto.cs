using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.DTOs
{
    public class TestMarkDto
    {
        public double Mark { get; set; } = 0;
        [Required(ErrorMessage = "Test Id Filed Is Required")]
        public Guid TestId { get; set; }
        [Required(ErrorMessage = "Student Id Filed Is Required")]
        public Guid StudentId { get; set; }
    }
}
