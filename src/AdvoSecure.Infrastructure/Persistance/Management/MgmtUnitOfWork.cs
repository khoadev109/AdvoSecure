using AdvoSecure.Application.Interfaces;
using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.Management.Repositories;
using AdvoSecure.Infrastructure.Persistance.Management;
using AdvoSecure.Infrastructure.Persistance.Management.Repositories;

namespace AdvoSecure.Infrastructure.Persistance.Management
{
    public class MgmtUnitOfWork : IMgmtUnitOfWork, IDisposable
    {
        private readonly MgmtDbContext _dbContext;

        private IRepository<RefreshToken> _refreshTokenRepository;

        private ITenantDirectoryRepository _tenantDirectoryRepository;

        private ITenantSettingRepository _tenantSettingRepository;

        private ITenantUserRepository _tenantUserRepository;

        public MgmtUnitOfWork(MgmtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<RefreshToken> RefreshTokenRepository
        {
            get { return _refreshTokenRepository ??= new Repository<RefreshToken>(_dbContext); }
        }

        public ITenantDirectoryRepository TenantDirectoryRepository
        {
            get { return _tenantDirectoryRepository ??= new TenantDirectoryRepository(_dbContext); }
        }

        public ITenantSettingRepository TenantSettingRepository
        {
            get { return _tenantSettingRepository ??= new TenantSettingRepository(_dbContext); }
        }

        public ITenantUserRepository TenantUserRepository
        {
            get { return _tenantUserRepository ??= new TenantUserRepository(_dbContext); }
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
