using EventBus.Base.Abstraction;
using Microsoft.EntityFrameworkCore;
using PersonContactInfo.Application.IntegrationEvents;
using UserContactInformation.Inftastructure.Context;

namespace PersonContactInfo.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void SubscribeEventBus(this WebApplication app)
        {
            var eventBus = app.Services.GetRequiredService<IEventBus>();

            eventBus.Subscribe<LocationReportRequestedIntegrationEvent, LocationReportRequestedIntegrationEventHandler>();
        }

        public static void DatabaseMigrate(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                dataContext.Database.Migrate();
            }
        }
    }
}
