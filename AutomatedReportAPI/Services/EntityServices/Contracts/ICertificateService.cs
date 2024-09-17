namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface ICertificateService<T>
    {
        Task<T> GetAllCertificates();
    }
}
