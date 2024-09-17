using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class LoginRequste
    {
        [Required(ErrorMessage = "User Type Filed Is Required")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Password Filed Is Required")]
        public string Password { get; set; }
    }
}
