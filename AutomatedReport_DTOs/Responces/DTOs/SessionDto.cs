namespace AutomatedReportCore.Responces.DTOs
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public string Class { get; set; }        
        public string Subject { get; set; }
        public string Hall { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
