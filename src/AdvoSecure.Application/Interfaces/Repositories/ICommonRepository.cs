using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Language;

using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        IQueryable<BillingRate> GetBillingRates();

        IQueryable<CompanyLegalStatus> GetCompanyLegalStatuses();

        IQueryable<Country> GetCountries();
        IQueryable<Language> GetLanguages();
        IQueryable<TaskType> GetTaskTypes();
    }
}
