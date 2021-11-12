using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sociussion.Data;
using Sociussion.Models;
using Sociussion.Services.Token;

namespace Sociussion.Services
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var tokenConfiguration = configuration.GetSection("Auth:Jwt").Get<TokenConfiguration>();

            services
                .AddDefaultIdentity<ApplicationUser>(config =>
                {
                    config.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = tokenConfiguration.Issuer,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret)),
                        ValidAudience = tokenConfiguration.Audience,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true
                    };
                });

            return services;
        }
    }
}
