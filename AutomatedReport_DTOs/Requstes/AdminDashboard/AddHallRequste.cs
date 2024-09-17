using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class AddHallRequste
    {
        [Required(ErrorMessage = "Name Filed Is Required")]
        public string name { get; set; }
    }
}
