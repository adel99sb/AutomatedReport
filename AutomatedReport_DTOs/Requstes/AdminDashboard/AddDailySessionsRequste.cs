using AutomatedReportCore.Requstes.DTOs;
using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class AddDailySessionsRequste
    {
        [Required(ErrorMessage = "Daily Session List Filed Is Required")]
        public List<DailySessionDto> DailySessionList { get; set; }
    }
}
