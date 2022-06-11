using EventBus.Base.Abstraction;
using Report.Application.Exceptions;
using Report.Application.Interfaces.Repositories;

namespace Report.Application.IntegrationEvents
{
    public class LocationReportGeneratedIntegrationEventHandler : IIntegrationEventHandler<LocationReportGeneratedIntegrationEvent>
    {
        private readonly ILocationReportRepository locationReportRepository;
        private readonly ILocationReportResultRepository locationReportResultRepository;

        public LocationReportGeneratedIntegrationEventHandler(ILocationReportRepository locationReportRepository, ILocationReportResultRepository locationReportResultRepository)
        {
            this.locationReportRepository = locationReportRepository;
            this.locationReportResultRepository = locationReportResultRepository;
        }

        public async Task Handle(LocationReportGeneratedIntegrationEvent @event)
        {
            var locationReport = await locationReportRepository.GetByIdAsync(@event.Id);

            if (locationReport is null)
            {
                throw new NotFoundException();
            }

            foreach (var item in @event.Report)
            {
                await locationReportResultRepository.AddAsync(new Domain.Entities.LocationReportResult()
                {
                    LocationReportId = locationReport.Id,
                    Location = item.Location,
                    PersonCount = item.PersonCount,
                    PhoneNumberCount = item.PhoneCount
                });
            }
 
            locationReport.State = Domain.Enums.EnmLocationReportState.Completed;

            await locationReportRepository.UpdateAsync(locationReport);
        }
    }
}
