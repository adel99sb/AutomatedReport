using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface ITeacherService<T>
    {
        Task<T> GetAllTeachers();
        Task<T> DeleteTeacher(Guid id);
        Task<T> GetTeacherById(Guid id);
        Task<T> EditeTeacher(EditeTeacherRequste requste);
        Task<T> AddTeacher(AddTeacherRequste requste);
    }
}
