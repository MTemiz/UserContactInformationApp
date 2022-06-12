using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Report.Application.Interfaces.Context;
using Report.Application.Interfaces.Repositories;
using Report.Infrastructure.Context;
using Report.Infrastructure.Repositories;

namespace Report.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILocationReportRepository, LocationReportRepository>();
            services.AddScoped<ILocationReportResultRepository, LocationReportResultRepository>();
        }
    }
}
