using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface ITestMarkService<T>
    {
        Task<T> AddTestMarks(AddTestMarkRequste requste);
        Task<T> GetAllTestMarks(Guid testId);
        Task<T> UpdateTestMarks(EditeTestMarksRequste requste);
    }
}
