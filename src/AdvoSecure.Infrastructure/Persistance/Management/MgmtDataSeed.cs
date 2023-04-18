using AdvoSecure.Domain.Entities;
using AdvoSecure.Security;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Tenant
{
    public static class ASMgmtDataSeed
    {
        public static async Task SeedAsMgmtTables(MgmtDbContext context)
        {
            Guid tenantAdminIdentifier = Guid.NewGuid();

            Guid adminUserIndentifier = Guid.NewGuid();

            var (hash, salt) = PasswordHelper.HashPassword("admin");

            if (!context.TenantSettings.Any() && !context.TenantUsers.Any())
            {
                await context.TenantSettings.AddAsync(
                    new TenantSetting
                    {
                        Name = "Mgmt Admin",
                        SchemaName = "ASMGMT",
                        TenantIdentifier = tenantAdminIdentifier,
                        ConnectionString = "Server=localhost;Database=ASMGMT;Port=5432;User Id=postgres;Password=password;Ssl Mode=Prefer;Trust Server Certificate=true",
                        CreatedBy = "TOAA"
                    }
                );

                await context.TenantUsers.AddAsync(
                    new TenantUser
                    {
                        UserIdentifier = adminUserIndentifier,
                        Name = "Tenant User Admin",
                        FirstName = "User",
                        LastName = "Admin",
                        PasswordHash = hash,
                        PasswordSalt = salt,
                        Email = "tenantadmin@gmail.com",
                        CreatedBy = "TOAA"
                    }
                );

                await context.SaveChangesAsync();

                if (!context.TenantDirectories.Any())
                {
                    TenantSetting tenantAdmin = await context.TenantSettings.SingleOrDefaultAsync(t => t.TenantIdentifier == tenantAdminIdentifier);

                    TenantUser userAdmin = await context.TenantUsers.SingleOrDefaultAsync(t => t.UserIdentifier == adminUserIndentifier);

                    var tenantDirectory = new TenantDirectory
                    {
                        Tenant = tenantAdmin,
                        User = userAdmin,
                        CreatedBy = "TOAA"
                    };

                    tenantAdmin.TenantDirectories.Add(tenantDirectory);

                    userAdmin.TenantDirectories.Add(tenantDirectory);

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
