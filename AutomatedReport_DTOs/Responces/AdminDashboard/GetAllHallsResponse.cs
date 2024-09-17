using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllHallsResponse
    {
        public List<HallDto> halls { get; set; } = new();
    }
}
