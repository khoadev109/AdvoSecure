using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AdvoSecure.Infrastructure.Swagger
{
    public static class SwaggerConfig
	{
		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AdvoSecure API", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Name = "Bearer",
							In = ParameterLocation.Header,
							Reference = new OpenApiReference
							{
								Id = "Bearer",
								Type = ReferenceType.SecurityScheme
							}
						},
						new List<string>()
					}
				});
			});

			return services;
		}
	}
}
