using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class GetAllSessionsByDayRequste
    {
        [Required(ErrorMessage = "Division Id Filed Is Required")]
        public Guid DivisionId { get; set; }
        [Required(ErrorMessage = "Day Filed Is Required")]
        public DayOfWeek Day { get; set; }
    }
}
