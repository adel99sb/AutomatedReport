using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface IUserService<T>
    {
        Task<T> Login(LoginRequste request);
        Task<T> GetAllUsers();
        Task<T> EditeUserPassword(EditeUserPasswordRequste request);
    }
}
