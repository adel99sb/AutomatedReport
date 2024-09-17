namespace AutomatedReportCore.Responces.DTOs
{
    public class TestDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalMark { get; set; }
        public bool IsDone { get; set; }
        public string Subject { get; set; }
    }
}
