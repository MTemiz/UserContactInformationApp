using EventBus.Base.Events;
using PersonContactInfo.Application.IntegrationModels;

namespace PersonContactInfo.Application.IntegrationEvents
{
    public class LocationReportGeneratedIntegrationEvent : IntegrationEvent
    {
        public List<LocationBasedReportIntegrationDto> Report { get; private set; }

        public LocationReportGeneratedIntegrationEvent(Guid id, List<LocationBasedReportIntegrationDto> Report) : base(id, DateTime.Now)
        {
            this.Report = Report;
        }
    }
}
