using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface IDailySessionsService<T>
    {
        Task<T> GetAllDailySessions(Guid divissionId);
        Task<T> GetAllDailySessionsByDate(GetAllDailySessionsByDateRequste requste);
        Task<T> AddDailySessions(AddDailySessionsRequste requste);

    }
}
