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
using AdvoSecure.Domain.Interfaces;
using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.App.Repositories;
using AdvoSecure.Infrastructure.Persistance.Application.Repositories;

namespace AdvoSecure.Infrastructure.Persistance.Application
{
    public class AppUnitOfWork : IAppUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        private IRepository<RefreshToken> _refreshTokenRepository;

        private IRepository<BillingRate> _billingRateRepository;

        private IRepository<BillingGroup> _billingGroupRepository;

        private IRepository<CompanyLegalStatus> _companyLegalStatusRepository;

        private IRepository<Country> _countryRepository;

        private IRepository<Language> _languageRepository;

        private IRepository<TaskType> _taskTypeRepository;

        private IContactRepository _contactRepository;

        private IRepository<ContactIdType> _contactIdTypeRepository;

        private IRepository<ContactCivilStatus> _contactCivilStatusRepository;

        private IMatterRepository _matterRepository;

        private IRepository<MatterType> _matterTypeRepository;

        private IRepository<MatterArea> _matterAreaRepository;

        private IRepository<CourtSittingInCity> _courtSittingInCityRepository;

        private IRepository<CourtGeoJurisdiction> _courtGeoJurisdictionRepository;

        private IRepository<Note> _noteRepository;

        private IRepository<NoteNotification> _noteNotificationRepository;

        private IOpportunityRepository _opportunityRepository;

        private IRepository<OpportunityContact> _opportunityContactRepository;

        private IRepository<Lead> _leadRepository;

        private IRepository<LeadStatus> _leadStatusRepository;

        private IRepository<LeadFee> _leadFeeRepository;

        private IRepository<LeadSource> _leadSourceRepository;

        private IRepository<LeadSourceType> _leadSourceTypeRepository;

        private IRepository<Invoice> _invoiceRepository;

        private IFeeRepository _feeRepository;

        private IRepository<InvoiceFee> _invoiceFeeRepository;

        private IExpenseRepository _expenseRepository;

        private IRepository<InvoiceExpense> _invoiceExpenseRepository;

        private IRepository<InvoiceTime> _invoiceTimeRepository;

        private IRepository<Time> _timeRepository;

        private IRepository<TimeCategory> _timeCategoryRepository;

        private IRepository<ContactTitle> _contactTitleRepository;

        private IRepository<Setting> _settingRepository;

        public AppUnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<RefreshToken> RefreshTokenRepository
        {
            get { return _refreshTokenRepository ??= new Repository<RefreshToken>(_dbContext); }
        }

        public IRepository<BillingRate> BillingRateRepository
        {
            get { return _billingRateRepository ??= new Repository<BillingRate>(_dbContext); }
        }

        public IRepository<BillingGroup> BillingGroupRepository
        {
            get { return _billingGroupRepository ??= new Repository<BillingGroup>(_dbContext); }
        }

        public IRepository<CompanyLegalStatus> CompanyLegalStatusRepository
        {
            get { return _companyLegalStatusRepository ??= new Repository<CompanyLegalStatus>(_dbContext); }
        }

        public IRepository<Country> CountryRepository
        {
            get { return _countryRepository ??= new Repository<Country>(_dbContext); }
        }

        public IRepository<Language> LanguageRepository
        {
            get { return _languageRepository ??= new Repository<Language>(_dbContext); }
        }

        public IRepository<TaskType> TaskTypeRepository
        {
            get { return _taskTypeRepository ??= new Repository<TaskType>(_dbContext); }
        }

        public IContactRepository ContactRepository
        {
            get { return _contactRepository ??= new ContactRepository(_dbContext); }
        }

        public IRepository<ContactIdType> ContactIdTypeRepository
        {
            get { return _contactIdTypeRepository ??= new Repository<ContactIdType>(_dbContext); }
        }

        public IRepository<ContactCivilStatus> ContactCivilStatusRepository
        {
            get { return _contactCivilStatusRepository ??= new Repository<ContactCivilStatus>(_dbContext); }
        }

        public IMatterRepository MatterRepository
        {
            get { return _matterRepository ??= new MatterRepository(_dbContext); }
        }

        public IRepository<MatterType> MatterTypeRepository
        {
            get { return _matterTypeRepository ??= new Repository<MatterType>(_dbContext); }
        }

        public IRepository<MatterArea> MatterAreaRepository
        {
            get { return _matterAreaRepository ??= new Repository<MatterArea>(_dbContext); }
        }

        public IRepository<CourtSittingInCity> CourtSittingInCityRepository
        {
            get { return _courtSittingInCityRepository ??= new Repository<CourtSittingInCity>(_dbContext); }
        }

        public IRepository<CourtGeoJurisdiction> CourtGeoJurisdictionRepository
        {
            get { return _courtGeoJurisdictionRepository ??= new Repository<CourtGeoJurisdiction>(_dbContext); }
        }

        public IRepository<Note> NoteRepository
        {
            get { return _noteRepository ??= new Repository<Note>(_dbContext); }
        }

        public IRepository<NoteNotification> NoteNotificationRepository
        {
            get { return _noteNotificationRepository ??= new Repository<NoteNotification>(_dbContext); }
        }

        public IOpportunityRepository OpportunityRepository
        {
            get { return _opportunityRepository ??= new OpportunityRepository(_dbContext); }
        }

        public IRepository<OpportunityContact> OpportunityContactRepository
        {
            get { return _opportunityContactRepository ??= new Repository<OpportunityContact>(_dbContext); }
        }

        public IRepository<Lead> LeadRepository
        {
            get { return _leadRepository ??= new Repository<Lead>(_dbContext); }
        }

        public IRepository<LeadStatus> LeadStatusRepository
        {
            get { return _leadStatusRepository ??= new Repository<LeadStatus>(_dbContext); }
        }

        public IRepository<LeadFee> LeadFeeRepository
        {
            get { return _leadFeeRepository ??= new Repository<LeadFee>(_dbContext); }
        }

        public IRepository<LeadSource> LeadSourceRepository
        {
            get { return _leadSourceRepository ??= new Repository<LeadSource>(_dbContext); }
        }

        public IRepository<LeadSourceType> LeadSourceTypeRepository
        {
            get { return _leadSourceTypeRepository ??= new Repository<LeadSourceType>(_dbContext); }
        }

        public IRepository<Invoice> InvoiceRepository
        {
            get { return _invoiceRepository ??= new Repository<Invoice>(_dbContext); }
        }

        public IFeeRepository FeeRepository
        {
            get { return _feeRepository ??= new FeeRepository(_dbContext); }
        }

        public IRepository<InvoiceFee> InvoiceFeeRepository
        {
            get { return _invoiceFeeRepository ??= new Repository<InvoiceFee>(_dbContext); }
        }

        public IExpenseRepository ExpenseRepository
        {
            get { return _expenseRepository ??= new ExpenseRepository(_dbContext); }
        }

        public IRepository<InvoiceExpense> InvoiceExpenseRepository
        {
            get { return _invoiceExpenseRepository ??= new Repository<InvoiceExpense>(_dbContext); }
        }

        public IRepository<InvoiceTime> InvoiceTimeRepository
        {
            get { return _invoiceTimeRepository ??= new Repository<InvoiceTime>(_dbContext); }
        }

        public IRepository<Time> TimeRepository
        {
            get { return _timeRepository ??= new Repository<Time>(_dbContext); }
        }

        public IRepository<TimeCategory> TimeCategoryRepository
        {
            get { return _timeCategoryRepository ??= new Repository<TimeCategory>(_dbContext); }
        }
        public IRepository<ContactTitle> ContactTitleRepository
        {
            get { return _contactTitleRepository ??= new Repository<ContactTitle>(_dbContext); }
        }

        public IRepository<Setting> SettingRepository
        {
            get { return _settingRepository ??= new Repository<Setting>(_dbContext); }
        }

        public async Task SetConnectionStringAndRunMigration(string connectionString)
        {
            await _dbContext.SetConnectionStringAndRunMigration(connectionString);
        }


        public void Commit() => _dbContext.SaveChanges();

        public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

        public void Rollback() => _dbContext.Dispose();

        public async Task RollbackAsync() => await _dbContext.DisposeAsync();


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
