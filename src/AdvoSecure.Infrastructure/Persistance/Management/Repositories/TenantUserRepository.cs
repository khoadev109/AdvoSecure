using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using AdvoSecure.Security;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Management.Repositories
{
    public class TenantUserRepository : Repository<TenantUser>, ITenantUserRepository
    {
        public TenantUserRepository(MgmtDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckPasswordAsync(string userName, string password)
        {
            TenantUser user  = await GetAsync(u => u.Email == userName);

            if (user == null)
            {
                return false;
            }

            var isValidPassword = PasswordHelper.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);

            return isValidPassword;
        }

        public async Task<TenantUser> CreateAsync(RegisterRequest request, string userName)
        {
            var (hash, salt) = PasswordHelper.HashPassword(request.Password);

            TenantUser user = new()
            {
                Email = request.Email,
                Name = request.DisplayName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = hash,
                PasswordSalt = salt,
                UserIdentifier = Guid.NewGuid(),
                CreatedBy = userName
            };

            await AddAsync(user);

            return user;
        }
    }
}
