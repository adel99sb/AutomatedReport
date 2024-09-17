using AutomatedReportCore.Responces.DTOs;

namespace AutomatedReportCore.Responces.AdminDashboard
{
    public class GetAllPhoneNumbersResponse
    {
        public List<string> PhoneNumbers { get; set; } = new();
    }
    public class GetTodayBirthDayNumbersResponse
    {
        public List<BirthdayDto> Birthdays { get; set; } = new();
    }
}
