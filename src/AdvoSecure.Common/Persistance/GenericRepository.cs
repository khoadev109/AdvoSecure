using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Common.Persistance
{
    public class GenericRepository<TDbContext, TEntity> : IGenericRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        protected readonly TDbContext _dbContext;

        protected GenericRepository(TDbContext context)
        {
            _dbContext = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
