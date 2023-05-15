using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Application.Mappers;
using AdvoSecure.Application.Services;
using AdvoSecure.Application.Validators;
using AdvoSecure.Common;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecure.Application
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MgmtProfile), typeof(ApplicationProfile), typeof(DomainProfile));
            services.AddValidatorsFromAssemblyContaining<CaseFilterValidator>();

            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IMatterService, MatterService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IOpportunityService, OpportunityService>();
        }
    }
}
