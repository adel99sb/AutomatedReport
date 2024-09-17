using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllStudentsWithDivisionResponse
    {
        public List<StudentDto> students { get; set; } = new();
    }
}
