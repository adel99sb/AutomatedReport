using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllSubjectsResponse
    {
        public List<SubjectDto> subjects { get; set; } = new();
    }
}
