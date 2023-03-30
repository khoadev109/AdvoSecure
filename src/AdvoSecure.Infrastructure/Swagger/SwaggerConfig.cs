using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AdvoSecure.Infrastructure.Swagger
{
	public static class SwaggerConfig
	{
		public static IServiceCollection ConfigureSwaggerApi(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSwaggerGen(options =>
			{
				var authUrl = configuration["AzureAd:AuthorizationUrl"];
				var tokenUrl = configuration["AzureAd:TokenUrl"];
				//var scope = configuration["AzureAd:Scope"];
				options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
				{
					Type = SecuritySchemeType.OAuth2,
					Flows = new OpenApiOAuthFlows
					{
						Implicit = new OpenApiOAuthFlow
						{
							AuthorizationUrl = new Uri(authUrl),
							TokenUrl = new Uri(tokenUrl),
							Scopes = new Dictionary<string, string>
								{
									//{ scope, scope },
									{ "openid", "openid" },
									{ "email", "email" },
									{ "profile", "profile" }
								}
						}

					}
				});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "oauth2"
							},
							Scheme = "oauth2",
							Name = "oauth2",
							In = ParameterLocation.Header
						},
						new List<string>()
					}
				});
			});

			return services;
		}
	}
}
