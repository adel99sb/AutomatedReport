namespace AutomatedReportAPI.Services.EntityServices.Contracts
{
    public interface ISubjectService<T>
    {
        Task<T> GetAllSubjects(Guid divisionId);
    }
}
