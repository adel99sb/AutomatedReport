using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class EditeDivisionRequste : AddDivisionRequste
    {
        [Required(ErrorMessage = "Division Id Filed Is Required")]
        public Guid id { get; set; }
    }
}
