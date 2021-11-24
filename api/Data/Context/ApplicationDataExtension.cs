using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sociussion.Data.Interfaces;

namespace Sociussion.Data.Context
{
    public static class ApplicationDataExtension
    {
        public static IServiceCollection AddApplicationDbContext(
            this IServiceCollection services,
            IConfiguration config)
        {
            services
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite(config.GetConnectionString("DefaultConnection"));
                });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
