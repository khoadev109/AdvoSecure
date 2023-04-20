using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.BillingEntities;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        IQueryable<BillingRate> GetBillingRates();

        IQueryable<Country> GetCountries();
    }
}
