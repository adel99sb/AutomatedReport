using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class DailySessions_Record
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public Guid Sessions_RecordId { get; set; }
        public Sessions_Record  Sessions_Record { get; set; }
        [Required]
        public string Subject_Title { get; set; }

    }
}
