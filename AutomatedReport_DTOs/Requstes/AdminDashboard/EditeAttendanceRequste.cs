using AutomatedReportCore.Requstes.DTOs;
using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class EditeAttendanceRequste
    {
        [Required(ErrorMessage = "Attendances List Filed Is Required")]
        public List<AddAttendanceDto> AttendancesList { get; set; }
    }
}
