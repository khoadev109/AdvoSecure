using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Common.Persistance
{
    public interface IGenericRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
