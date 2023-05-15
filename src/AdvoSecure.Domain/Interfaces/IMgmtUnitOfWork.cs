using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Interfaces;
using AdvoSecure.Domain.Interfaces.Repositories;

namespace AdvoSecure.Application.Interfaces
{
    public interface IMgmtUnitOfWork : IUnitOfWork
    {
        IRepository<RefreshToken> RefreshTokenRepository { get; }

        ITenantDirectoryRepository TenantDirectoryRepository { get; }

        ITenantSettingRepository TenantSettingRepository { get; }

        ITenantUserRepository TenantUserRepository { get; }

        void Commit();

        void Rollback();

        Task CommitAsync();

        Task RollbackAsync();
    }
}
