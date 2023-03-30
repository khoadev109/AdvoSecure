using AdvoSecureTenant.Api;
using AdvoSecureTenant.Core;
using AdvoSecureTenant.Core.Persistance;
using AdvoSecureTenant.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddDebug();
    builder.SetMinimumLevel(LogLevel.Information);
});

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(jtwOptions =>
        {
            jtwOptions.Events = new TenantJwtBearerEvents(loggerFactory.CreateLogger<TenantJwtBearerEvents>());
        },
        msIdentityOptions =>
        {
            configuration.GetSection("AzureAd").Bind(msIdentityOptions);
        }
);

builder.Services.AddAuthorization();

IdentityModelEventSource.ShowPII = false;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwaggerApi(configuration);

var corsPolicy = "CorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder => builder
        .WithOrigins(configuration["Client:ValidOrigin"] ?? string.Empty)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddMappers();
builder.Services.AddTenantDbContext();
builder.Services.AddScoped<TenantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

await app.BootstrapPostgres();

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
