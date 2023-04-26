using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.BillingEntities;
using AdvoSecure.Domain.Entities.Language;
using AdvoSecure.Domain.Entities.TaskType;

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
