using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class EditeHallRequste : AddHallRequste
    {
        [Required(ErrorMessage = "Hall Id Filed Is Required")]
        public Guid id { get; set; }
    }
}
