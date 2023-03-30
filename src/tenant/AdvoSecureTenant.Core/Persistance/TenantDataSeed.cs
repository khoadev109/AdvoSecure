using AdvoSecureTenant.Core.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecureTenant.Core.Persistance
{
    public static class TenantDataSeed
    {
        public static async Task SeedTenantTables(TenantDbContext context)
        {

            if (!context.Tenants.Any())
            {
                await context.Tenants.AddRangeAsync(
                        new Tenant
                        {
                            Name = "identifier-2cc9fb16-095d-4215-9b87-60ce9cab3c2d",
                            SchemaName = "db-2cc9fb16-095d-4215-9b87-60ce9cab3c2d",
                            AzureTenantId = "f34b813a-5d56-48d0-811b-96b3de505340",
                            ConnectionString = "Server=localhost;Database=advosecuretenantdb;Port=5432;User Id=postgres;Password=password;Ssl Mode=Prefer;Trust Server Certificate=true"
                        } // this will be configured to get dynamically from secrect place
                );
            }

            if (!context.TenantSettings.Any())
            {
                await context.TenantSettings.AddRangeAsync(
                        new TenantSetting
                        {
                            AdminTenantId = 1,
                            AvailableTenants = new List<string>
                            {
                                "f34b813a-5d56-48d0-811b-96b3de505340", //Admin tenant
                                "19684df9-0335-4998-9151-e5c4f9607c47", //Tenant one
                                "10d4db3f-c367-4b6b-bcd8-fa6708510fd2" //Tenant two
                            }
                        }
                );
            }

            await context.SaveChangesAsync();
        }
    }
}
