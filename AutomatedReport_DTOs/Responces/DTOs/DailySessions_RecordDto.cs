namespace AutomatedReportCore.Responces.DTOs
{
    public class DailySessions_RecordDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Hall { get; set; }
        public string Class { get; set; }
        public string Day { get; set; }
        public Guid Sessions_RecordId{ get; set; }
        public string SubjectName { get; set; }
        public string Subject_Title { get; set; }
    }
}
