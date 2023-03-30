using AdvoSecure.Api;
using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Models.Validatiors;
using AdvoSecure.Application.Mappers;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Exceptions;
using AdvoSecure.Infrastructure.Notifications;
using AdvoSecure.Infrastructure.Persistance;
using AdvoSecure.Infrastructure.Services;
using AdvoSecure.Infrastructure.Swagger;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
var env = builder.Environment;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddDebug();
    builder.SetMinimumLevel(LogLevel.Information);
});

services.AddHttpClient("TenantApi", configureClient =>
{
    configureClient.BaseAddress = new Uri(configuration["Tenant:BaseApiUrl"] ?? string.Empty);
    configureClient.DefaultRequestHeaders.Add("Accept", "application/json");
});

services.AddDistributedMemoryCache();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(jtwOptions =>
        {
            jtwOptions.Events = new AdvoJwtBearerEvents(loggerFactory.CreateLogger<AdvoJwtBearerEvents>());
        },
        msIdentityOptions =>
        {
            configuration.GetSection("AzureAd").Bind(msIdentityOptions);
        }
);

services.AddAuthorization();

services.AddControllers(options =>
{
    options.Filters.Add(typeof(ExceptionResultFilterAttribute));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new ExceptionConverter());
});

services.AddEndpointsApiExplorer();

services.ConfigureSwaggerApi(configuration);

var corsPolicy = "CorsPolicy";

services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder => builder
        .WithOrigins(configuration["Client:ValidOrigin"] ?? string.Empty)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

services.AddMemoryCache();
services.AddSingleton<CacheProvider, CacheProvider>();
services.AddSignalR();
services.AddMappers();
services.AddValidatorsFromAssemblyContaining<CaseFilterValidator>();
services.AddApplicationDbContext();
services.AddRepositories();
services.AddServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notify");

app.Run();
