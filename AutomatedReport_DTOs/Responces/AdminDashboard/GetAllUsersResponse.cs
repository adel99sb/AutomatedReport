using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllUsersResponse
    {
        public List<UserDto> users { get; set; } = new();
    }
}
