namespace AutomatedReportAPI.Services.BackgroundJobs
{
    public interface IBackgourndJobService
    {
        Task SendBirthDayMessage(string Message, DateTime birthdayDate);
    }
}
