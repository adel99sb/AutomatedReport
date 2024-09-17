using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllDaysResponse
    {
        public List<DayDto> days { get; set; } = new();
    }
}