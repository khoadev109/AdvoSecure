using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.App.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            IEnumerable<Case> Cases = await _dbContext.Cases.ToListAsync<Case>();
            return Cases;
        }
    }
}
