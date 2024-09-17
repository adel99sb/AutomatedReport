using AutomatedReportAPI.AppData.Models;
using AutomatedReportCore.Requstes.AdminDashboard;

namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface IDivisionService<T>
    {
        Task<T> AddDivision(AddDivisionRequste requste);
        Task<T> GetAllDivisionsWithStudentsNomber(Guid certificateId);
        Task<T> GetDivisionById(Guid id);
        Task<T> EditeDivision(EditeDivisionRequste requste);
        Task<T> DeleteDivision(Guid id);
        Task<T> GetAllDivisions(Guid? certificateId);
    }
}
