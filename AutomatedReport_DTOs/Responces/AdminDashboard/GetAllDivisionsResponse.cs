using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllDivisionsResponse
    {
        public List<DivisionDto> divisions { get; set; } = new();
    }
}
