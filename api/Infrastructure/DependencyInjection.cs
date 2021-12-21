using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sociussion.Application.Common.Interfaces;
using Sociussion.Application.Services;
using Sociussion.Domain.Entities;
using Sociussion.Infrastructure.Identity;
using Sociussion.Infrastructure.Persistence;
using Sociussion.Infrastructure.Services;

namespace Sociussion.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options
                .UseSqlite(config.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging();
        });

        services.AddApplicationIdentity(config);
        
        services.AddScoped<IDateTime, DateTimeService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<ICommunityService, CommunityService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IDiscussionService, DiscussionService>();

        return services;
    }

    private static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
    {
        var jwtConfig = config.GetJwtConfiguration();
        
        services
            .AddDefaultIdentity<ApplicationUser>(c =>
            {
                c.User.RequireUniqueEmail = true;
                c.Password.RequiredLength = 10;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret))
                };
            });

        return services;
    }
}