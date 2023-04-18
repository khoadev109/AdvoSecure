using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using AdvoSecure.Security;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Management.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MgmtDbContext _dbContext;

        public UserRepository(MgmtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckPasswordAsync(string userName, string password)
        {
            TenantUser user  = await _dbContext.TenantUsers.SingleOrDefaultAsync(u => u.Email == userName);

            if (user == null)
            {
                return false;
            }

            var isValidPassword = PasswordHelper.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);

            return isValidPassword;
        }

        public async Task<TenantUser> FindByEmailAsync(string email)
        {
            TenantUser user = await _dbContext.TenantUsers.SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<TenantUser> FindByUserIdentifierAsync(Guid userIdentifier)
        {
            TenantUser user = await _dbContext.TenantUsers.SingleOrDefaultAsync(u => u.UserIdentifier == userIdentifier);
            return user;
        }

        public async Task<TenantUser> CreateAsync(RegisterRequest request)
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
                CreatedBy = "TOAA"
            };

            await _dbContext.TenantUsers.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<TenantUser> SaveAsync(TenantUser user)
        {
            _dbContext.TenantUsers.Update(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<IQueryable<TenantUser>> GetAllAsync()
        {
            IQueryable<TenantUser> users = _dbContext.TenantUsers.AsQueryable<TenantUser>();

            return users;
        }
    }
}
