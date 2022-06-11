using EventBus.Base.Events;
using Report.Application.IntegrationDtos;

namespace Report.Application.IntegrationEvents
{
    public class LocationReportGeneratedIntegrationEvent : IntegrationEvent
    {
        public List<LocationBasedReportIntegrationDto> Report { get; set; }
    }
}
