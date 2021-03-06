using EventBus.Base.Abstraction;
using Microsoft.EntityFrameworkCore;
using PersonContactInfo.Application.IntegrationModels;
using PersonContactInfo.Application.Interface.Repository;

namespace PersonContactInfo.Application.IntegrationEvents
{
    public class LocationReportRequestedIntegrationEventHandler : IIntegrationEventHandler<LocationReportRequestedIntegrationEvent>
    {
        private readonly IContactRepository contactRepository;
        private readonly IEventBus eventBus;

        public LocationReportRequestedIntegrationEventHandler(IEventBus eventBus, IContactRepository contactRepository)
        {
            this.eventBus = eventBus;
            this.contactRepository = contactRepository;
        }

        public async Task Handle(LocationReportRequestedIntegrationEvent @event)
        {
            await Task.Delay(10000);

            var contactList = await contactRepository.GetAllAsync();

            var locationBasedReport = contactList
               .GroupBy(p => p.Location)
               .Select(locations => new LocationBasedReportIntegrationDto()
               {
                   Location = locations.Key,
                   PhoneCount = locations.Select(c => c.Phone).Distinct().Count(),
                   PersonCount = locations.Select(c => c.PersonId).Distinct().Count()
               }).ToList();

            eventBus.Publish(new LocationReportGeneratedIntegrationEvent(@event.Id, locationBasedReport));

            await Task.CompletedTask;
        }
    }
}
