using System.ComponentModel.DataAnnotations;

namespace AutomatedReportCore.Requstes.DTOs
{
    public class DailySessionDto
    {
        [Required(ErrorMessage = "Date Filed Is Required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Sessions Record Id Filed Is Required")]
        public Guid Sessions_RecordId { get; set; }
        [Required(ErrorMessage = "Subject Title Filed Is Required")]
        public string Subject_Title { get; set; }
        public bool IsAlreadyExist { get; set; }
        public Guid? DailySessionId { get; set; }
    }
}
