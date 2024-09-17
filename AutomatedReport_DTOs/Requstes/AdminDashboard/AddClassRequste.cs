using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class AddClassRequste
    {
        [Required(ErrorMessage = "Name Filed Is Required")]
        public string name { get; set; }
        [Required(ErrorMessage = "From Time Filed Is Required")]
        public string from_Time { get; set; }
        [Required(ErrorMessage = "To Time Filed Is Required")]
        public string to_Time { get; set; }
    }
}
