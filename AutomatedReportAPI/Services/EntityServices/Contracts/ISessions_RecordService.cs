using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface ISessions_RecordService<T>
    {
        Task<T> GetAllSessionsGroupedByDays(Guid divisionId);
        Task<T> GetAllSessions(Guid divisionId);
        Task<T> GetAllSessionsByDay(GetAllSessionsByDayRequste requste);
        Task<T> GetAllDays();
        Task<T> EditeSession(EditeSessionRequste requste);
        Task<T> DeleteSession(Guid id);
        Task<T> AddSession(AddSessionRequste requste);

    }
}
