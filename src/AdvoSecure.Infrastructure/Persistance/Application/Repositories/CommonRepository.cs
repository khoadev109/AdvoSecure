using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Language;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Tasks;

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

        public IQueryable<Language> GetLanguages()
        {
            return _dbContext.Languages;
        }

        public IQueryable<TaskType> GetTaskTypes()
        {
            return _dbContext.TaskTypes;
        }
    }
}
