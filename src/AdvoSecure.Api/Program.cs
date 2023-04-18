using AdvoSecure.Api.Areas.Application.Models.Validators;
using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Authentication;
using AdvoSecure.Application.Mappers;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Exceptions;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Infrastructure.Notifications;
using AdvoSecure.Infrastructure.Persistance;
using AdvoSecure.Infrastructure.Services;
using AdvoSecure.Infrastructure.Swagger;
using AdvoSecure.Security;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
var env = builder.Environment;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddDebug();
    builder.SetMinimumLevel(LogLevel.Information);
});

services.AddHttpClient("AdvosecureApi", configureClient =>
{
    configureClient.BaseAddress = new Uri(configuration["Tenant:BaseApiUrl"] ?? string.Empty);
    configureClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

services.AddDistributedMemoryCache();

services.AddMgmtDbContext();
services.AddAppDbContext();

services.AddIdentityDb();

services.AddHttpContextAccessor();

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new JwtResolver(configuration).GetTokenParameters();
});

services.AddAuthorization();
services.AddScoped<IPermissionService, PermissionService>();
services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

services.AddControllers(options =>
{
    options.Filters.Add(typeof(ExceptionResultFilterAttribute));
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new ExceptionConverter());
});


var corsPolicy = "CorsPolicy";

var validOrigins = configuration.GetSection("Client:ValidOrigins").Get<string[]>() ?? new string[] {};

services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder => builder
        .WithOrigins(validOrigins)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

services.AddEndpointsApiExplorer();
services.AddMemoryCache();
services.AddSignalR();
services.AddSwagger();
services.AddMappers();
services.AddValidatorsFromAssemblyContaining<CaseFilterValidator>();
services.AddRepositories();
services.AddServices();
services.AddScoped<JwtResolver>();
services.AddScoped<RsaResolver>();
services.AddSingleton<CacheProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

await DataInitializer.BootstrapPostgres(app);

app.UseCors(corsPolicy);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notify");

app.Run();
