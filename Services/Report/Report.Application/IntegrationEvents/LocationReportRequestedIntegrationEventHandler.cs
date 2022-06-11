using EventBus.Base.Abstraction;
using Microsoft.Extensions.Logging;

namespace Report.Application.IntegrationEvents
{
    public class LocationReportRequestedIntegrationEventHandler : IIntegrationEventHandler<LocationReportRequestedIntegrationEvent>
    {
        private readonly ILogger<LocationReportRequestedIntegrationEventHandler> logger;
        private readonly IEventBus eventBus;

        public LocationReportRequestedIntegrationEventHandler(ILogger<LocationReportRequestedIntegrationEventHandler> logger, IEventBus eventBus)
        {
            this.logger = logger;
            this.eventBus = eventBus;
        }

        public Task Handle(LocationReportRequestedIntegrationEvent @event)
        {
            eventBus.Publish(@event);

            return Task.CompletedTask;
        }
    }
}
