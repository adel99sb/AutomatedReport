using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface IAttendanceService<T>
    {
        Task<T> EditeAttendance(EditeAttendanceRequste requste);
        Task<T> GetAttendanceByDate(DateTime date,Guid DivisionId);
    }
}
