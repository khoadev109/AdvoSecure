using AdvoSecure.Api;
using AdvoSecure.Api.Attributes;
using AdvoSecure.Domain.Exceptions;
using AdvoSecure.Infrastructure.Notifications;
using AdvoSecure.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;

builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ExceptionResultFilterAttribute));
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new ExceptionConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

await DataInitializer.BootstrapPostgres(app);

app.UseCors(builder.Configuration["CorsPolicy"] ?? string.Empty);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notify");

app.Run();
