namespace AutomatedReportAPI.Infrastructure
{
    public interface IUnitOfWork<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(Guid id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(Guid id);
    }
}
