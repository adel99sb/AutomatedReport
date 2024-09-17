using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface IStudentService<T>
    {
        Task<T> GetAllStudentsWithDivision();
        Task<T> GetAllStudentsByTestId(Guid testId);
        Task<T> GetAllStudentsByDivisionId(Guid divisionId);
        Task<T> DeleteStudent(Guid id);
        Task<T> AddStudent(AddStudentRequste requste);
        Task<T> EditeStudent(EditeStudentRequste requste);
        Task<T> GetStudentById(Guid id);
        Task<T> MoveStudentToGratitude(Guid id);
    }
}
