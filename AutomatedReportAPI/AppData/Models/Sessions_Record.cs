namespace AutomatedReportAPI.AppData.Models
{
    public class Sessions_Record
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DivisionId { get; set; }
        public Guid _ClassId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid HallId { get; set; }
        public DayOfWeek day { get; set; }
        public Division Division { get; set; }
        public _Class Class { get; set; }
        public Subject Subject { get; set; }
        public Hall Hall { get; set; }
    }    
}
