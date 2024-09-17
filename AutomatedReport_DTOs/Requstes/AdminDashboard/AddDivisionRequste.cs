using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class AddDivisionRequste
    {
        [Required(ErrorMessage = "Division Name Filed Is Required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Certificate Id Filed Is Required")]
        public Guid certificateId { get; set; }
    }
}
