using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class AddTeacherRequste
    {
        [Required(ErrorMessage = "Full Name Filed Is Required")]
        public string full_Name { get; set; }
        public string? phone { get; set; }
    }
}
