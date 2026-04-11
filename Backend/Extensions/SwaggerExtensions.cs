using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Backend.Extensions;

/// <summary>
/// Provides extension methods for configuring Swagger UI and API documentation generation.
/// </summary>
public static class SwaggerExtensions
{
/// <summary>
    /// Configures and registers Swagger with JWT support.
    /// </summary>
    /// <remarks>
    /// This configuration includes:
    /// API details for ServiceHub (v1)
    /// XML comments integration (Requires <c>GenerateDocumentationFile = true</c> in the .csproj)
    /// Security definitions to authorize endpoints using Bearer JWT tokens in the Swagger UI.
    /// </remarks>
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "ServiceHub API", 
                Version = "v1",
                Description = "API Documentation for ServiceHub with JWT Authentication support."
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter the token.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                }
            });
        });

        return services;
    }

    /// <summary>
    /// Enables Swagger and Swagger UI middlewares in the application (Development environment only, for security reasons).
    /// </summary>
    public static void UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServiceHub API v1");
            c.RoutePrefix = "swagger"; 
        });
    }
}
