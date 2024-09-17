using AutomatedReportAPI.AppData.Context;
using Microsoft.EntityFrameworkCore;

namespace AutomatedReportAPI.Infrastructure
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>
    where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var result = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Entry(result).State = EntityState.Detached;
            return result;
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
