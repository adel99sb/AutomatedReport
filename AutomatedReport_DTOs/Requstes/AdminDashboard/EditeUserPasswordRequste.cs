using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class EditeUserPasswordRequste
    {
        [Required(ErrorMessage = "User Id Filed Is Required")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "New Password Filed Is Required")]
        [PasswordPropertyText]
        public string NewPassword { get; set; }
    }
}
