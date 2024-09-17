using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllTestMarksResponse
    {
        public List<TestMarkDto> testMarks { get; set; } = new();
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public double TotalMark { get; set; }
        public string Description { get; set; }
        public Guid TestId { get; set; }
    }
}
