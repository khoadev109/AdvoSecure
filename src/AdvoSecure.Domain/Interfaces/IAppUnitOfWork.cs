using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Leads;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Notes;
using AdvoSecure.Domain.Entities.Opportunities;
using AdvoSecure.Domain.Entities.Tasks;
using AdvoSecure.Domain.Entities.Timing;
using AdvoSecure.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Domain.Interfaces
{
    public interface IAppUnitOfWork : IUnitOfWork
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

        IRepository<CourtGeoJurisdiction> CourtGeoJurisdictionRepository { get; }

        IRepository<Note> NoteRepository { get; }

        IRepository<NoteNotification> NoteNotificationRepository { get; }

        IOpportunityRepository OpportunityRepository { get; }

        IRepository<OpportunityContact> OpportunityContactRepository { get; }

        IRepository<Lead> LeadRepository { get; }

        IRepository<LeadStatus> LeadStatusRepository { get; }

        IRepository<LeadFee> LeadFeeRepository { get; }

        IRepository<LeadSource> LeadSourceRepository { get; }

        IRepository<LeadSourceType> LeadSourceTypeRepository { get; }

        IRepository<Invoice> InvoiceRepository { get; }

        IFeeRepository FeeRepository { get; }

        IRepository<InvoiceFee> InvoiceFeeRepository { get; }

        IExpenseRepository ExpenseRepository { get; }

        IRepository<InvoiceExpense> InvoiceExpenseRepository { get; }

        IRepository<InvoiceTime> InvoiceTimeRepository { get; }

        IRepository<Time> TimeRepository { get; }

        IRepository<TimeCategory> TimeCategoryRepository { get; }

        IRepository<ContactTitle> ContactTitleRepository { get; }

        IRepository<Setting> SettingRepository { get; }

        Task SetConnectionStringAndRunMigration(string connectionString);

        void Commit();

        void Rollback();

        Task CommitAsync();

        Task RollbackAsync();
    }
}
