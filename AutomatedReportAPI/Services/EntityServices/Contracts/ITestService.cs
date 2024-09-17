using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface ITestService<T>
    {
        Task<T> GetAllTests(Guid divisionId);
        Task<T> DeleteTest(Guid id);
        Task<T> GetTestById(Guid id);
        Task<T> EditeTest(EditeTestRequste requste);
        Task<T> AddTest(AddTestRequste requste);
        Task<T> MarkAsDone(Guid id);
    }
}
