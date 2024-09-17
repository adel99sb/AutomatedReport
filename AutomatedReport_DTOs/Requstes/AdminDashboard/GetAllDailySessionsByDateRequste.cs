using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class GetAllDailySessionsByDateRequste
    {
        [Required(ErrorMessage = "Division Id Filed Is Required")]
        public Guid DivisionId { get; set; }
        [Required(ErrorMessage = "Date Filed Is Required")]
        public DateTime Date { get; set; }
    }
}
