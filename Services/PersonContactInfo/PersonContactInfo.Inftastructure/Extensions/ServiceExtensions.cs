using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonContactInfo.Application.Interface.Context;
using PersonContactInfo.Application.Interface.Repository;
using PersonContactInfo.Inftastructure.Context;
using PersonContactInfo.Inftastructure.Repositories;

namespace PersonContactInfo.Inftastructure.Extensions
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
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
