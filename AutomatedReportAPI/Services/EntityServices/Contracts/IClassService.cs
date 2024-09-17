using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface IClassService<T>
    {
        Task<T> GetAllClasses();
        Task<T> DeleteClass(Guid id);
        Task<T> GetClassById(Guid id);
        Task<T> AddClass(AddClassRequste requste);
        Task<T> EditeClass(EditeClassRequste requste);
    }   
}
