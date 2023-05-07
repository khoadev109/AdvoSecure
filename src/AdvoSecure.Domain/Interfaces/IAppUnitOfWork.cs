using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Notes;
using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Domain.Interfaces
{
    public interface IAppUnitOfWork
    {
        IRepository<RefreshToken> RefreshTokenRepository { get; }

        IRepository<BillingRate> BillingRateRepository { get; }

        IRepository<BillingGroup> BillingGroupRepository { get; }

        IRepository<CompanyLegalStatus> CompanyLegalStatusRepository { get; }

        IRepository<Country> CountryRepository { get; }

        IRepository<Language> LanguageRepository { get; }

        IRepository<TaskType> TaskTypeRepository { get; }

        IContactRepository ContactRepository { get; }

        IRepository<ContactIdType> ContactIdTypeRepository { get; }

        IRepository<ContactCivilStatus> ContactCivilStatusRepository { get; }

        IMatterRepository MatterRepository { get; }

        IRepository<MatterType> MatterTypeRepository { get; }

        IRepository<MatterArea> MatterAreaRepository { get; }

        IRepository<CourtSittingInCity> CourtSittingInCityRepository { get; }

        IRepository<CourtGeographicalJurisdiction> CourtGeographicalJurisdictionRepository { get; }

        IRepository<Note> NoteRepository { get; }

        IRepository<NoteNotification> NoteNotificationRepository { get; }

        void Commit();

        void Rollback();

        Task CommitAsync();

        Task RollbackAsync();
    }
}
