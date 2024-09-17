using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class LoginResponse
    {
        public UserDto user { get; set; } = new();
    }
}
