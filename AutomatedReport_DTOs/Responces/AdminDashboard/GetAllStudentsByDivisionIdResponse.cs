using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllStudentsByDivisionIdResponse
    {
        public List<StudentAttendanceDto> students { get; set; } = new();
    }    
}
