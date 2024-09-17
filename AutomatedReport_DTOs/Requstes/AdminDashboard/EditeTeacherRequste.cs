using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class EditeTeacherRequste : AddTeacherRequste
    {
        [Required(ErrorMessage = "Teacher Id Filed Is Required")]
        public Guid id { get; set; }
    }
}
