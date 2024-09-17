using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.DTOs
{
    public class AddAttendanceDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool IsAttend { get; set; }
    }
}
