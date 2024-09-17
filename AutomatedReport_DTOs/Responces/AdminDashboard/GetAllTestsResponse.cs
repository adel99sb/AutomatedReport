using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllTestsResponse
    {
        public List<TestDto> tests { get; set; } = new();
    }
}
