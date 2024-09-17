using System.ComponentModel.DataAnnotations;

namespace AutomatedReportAPI.AppData.Models
{
    public class Attendance
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsAttend { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public DailySessions_Record DailySessions_Record { get; set; }
        public Guid DailySessions_RecordId { get; set; }
    }
}
