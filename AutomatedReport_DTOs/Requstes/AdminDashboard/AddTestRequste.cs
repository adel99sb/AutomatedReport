using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.AdminDashboard
{
    public class AddTestRequste
    {
        [Required(ErrorMessage = "Description Filed Is Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Date Filed Is Required")]
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage = "Total Mark Filed Is Required")]
        public double TotalMark { get; set; }
        //public bool IsDone { get; set; } = false;
        [Required(ErrorMessage = "Subject Id Filed Is Required")]
        public Guid SubjectId { get; set; }
        [Required(ErrorMessage = "Division Id Filed Is Required")]
        public Guid DivisionId { get; set; }
    }
}
