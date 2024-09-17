using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllClassesResponse
    {
        public List<ClassDto> classes { get; set; } = new();
    }
}
