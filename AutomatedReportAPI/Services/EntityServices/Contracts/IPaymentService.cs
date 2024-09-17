using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface IPaymentService<T>
    {
        Task<T> GetAllPayments(Guid studentId);
        Task<T> AddPayment(AddPaymentRequste requste);
    }
}
