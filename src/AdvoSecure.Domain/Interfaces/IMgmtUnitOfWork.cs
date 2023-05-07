using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Application.Interfaces
{
    public interface IMgmtUnitOfWork
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
