using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllDailySessionsResponse
    {
        public List<DailySessions_RecordDto> dailySessions_Records { get; set; } = new();
    }
}
