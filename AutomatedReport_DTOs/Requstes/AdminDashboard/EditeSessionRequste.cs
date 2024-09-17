using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class EditeSessionRequste : AddSessionRequste
    {
        [Required(ErrorMessage = "Session Id Filed Is Required")]
        public Guid Id { get; set; }
    }
}
