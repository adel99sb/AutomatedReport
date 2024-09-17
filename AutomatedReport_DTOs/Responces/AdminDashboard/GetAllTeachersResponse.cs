using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllTeachersResponse
    {
        public List<TeacherDto> teachers { get; set; } = new();
    }
}
