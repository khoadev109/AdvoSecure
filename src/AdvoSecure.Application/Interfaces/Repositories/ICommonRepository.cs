using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Billings;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        IQueryable<BillingRate> GetBillingRates();

        IQueryable<CompanyLegalStatus> GetCompanyLegalStatuses();

        IQueryable<Country> GetCountries();
    }
}
