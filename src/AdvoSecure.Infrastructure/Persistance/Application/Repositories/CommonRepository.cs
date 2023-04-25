using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Billings;

namespace AdvoSecure.Infrastructure.Persistance.App.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<BillingRate> GetBillingRates()
        {
            return _dbContext.BillingRates;
        }

        public IQueryable<CompanyLegalStatus> GetCompanyLegalStatuses()
        {
            return _dbContext.CompanyLegalStatuses;
        }

        public IQueryable<Country> GetCountries()
        {
            return _dbContext.Countries;
        }
    }
}
