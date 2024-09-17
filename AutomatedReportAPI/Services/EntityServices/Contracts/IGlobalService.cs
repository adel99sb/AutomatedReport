namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface IGlobalService<T>
    {
        Task<T> GetAllStatistics();
        Task<T> GetAllPhoneNumbers();
        Task<T> GetTodayBirthDayNumbers();
    }
}
