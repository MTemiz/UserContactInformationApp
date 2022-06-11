using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserContactInformation.Application.Interface.Context;
using UserContactInformation.Application.Interface.Repository;
using UserContactInformation.Inftastructure.Context;
using UserContactInformation.Inftastructure.Repositories;

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
