using EventBus.Base.Events;

namespace Report.Application.IntegrationEvents
{
    public class LocationReportRequestedIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }

        public LocationReportRequestedIntegrationEvent(Guid id)
        {
            this.Id = id;
        }
    }
}
