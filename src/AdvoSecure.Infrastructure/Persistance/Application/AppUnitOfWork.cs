using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Notes;
using AdvoSecure.Domain.Entities.Tasks;
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

        private IRepository<CourtGeographicalJurisdiction> _courtGeographicalJurisdictionRepository;

        private IRepository<Note> _noteRepository;

        private IRepository<NoteNotification> _noteNotificationRepository;

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

        public IRepository<CourtGeographicalJurisdiction> CourtGeographicalJurisdictionRepository
        {
            get { return _courtGeographicalJurisdictionRepository ??= new Repository<CourtGeographicalJurisdiction>(_dbContext); }
        }

        public IRepository<Note> NoteRepository
        {
            get { return _noteRepository ??= new Repository<Note>(_dbContext); }
        }

        public IRepository<NoteNotification> NoteNotificationRepository
        {
            get { return _noteNotificationRepository ??= new Repository<NoteNotification>(_dbContext); }
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
