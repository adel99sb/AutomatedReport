using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface IHallService<T>
    {
        Task<T> GetAllHalls();
        Task<T> GetHallById(Guid id);
        Task<T> DeleteHall(Guid id);
        Task<T> AddHall(AddHallRequste requste);
        Task<T> EditeHall(EditeHallRequste requste);
    }
}
