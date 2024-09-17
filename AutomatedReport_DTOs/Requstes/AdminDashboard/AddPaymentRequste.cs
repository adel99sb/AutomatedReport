using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class AddPaymentRequste
    {
        [Required(ErrorMessage = "Value Filed Is Required")]
        public double value { get; set; }
        public string? description { get; set; }
        [Required(ErrorMessage = "Student Id Filed Is Required")]
        public Guid studentId { get; set; }
    }
}
