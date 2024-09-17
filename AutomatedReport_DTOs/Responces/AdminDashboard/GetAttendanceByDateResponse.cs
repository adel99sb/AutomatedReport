using AutomatedReportCore.Requstes.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAttendanceByDateResponse
    {        
        public List<GetAttendanceDto> attendances { get; set; } = new();
    }
}