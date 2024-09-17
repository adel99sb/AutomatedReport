using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class EditeClassRequste : AddClassRequste
    {
        [Required(ErrorMessage = "Class Id Filed Is Required")]
        public Guid id { get; set; }
    }
}
