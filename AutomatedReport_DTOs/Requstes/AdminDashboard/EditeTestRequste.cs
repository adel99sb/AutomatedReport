using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class EditeTestRequste : AddTestRequste
    {
        [Required(ErrorMessage = "Test Id Filed Is Required")]
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
    }
}
