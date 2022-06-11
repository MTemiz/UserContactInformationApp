using EventBus.Base.Abstraction;
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

            var contactList = contactRepository.GetAll();

            var locationBasedReport = contactList
               .GroupBy(p => p.Location)
               .Select(locations => new LocationBasedReportIntegrationDto()
               {
                   Location = locations.Key,
                   PhoneCount = locations.Select(c => c.Phone).Count(),
                   PersonCount = locations.Select(c => c.PersonId).Count()
               }).ToList();

            eventBus.Publish(new LocationReportGeneratedIntegrationEvent(@event.Id, new List<LocationBasedReportIntegrationDto>() { new LocationBasedReportIntegrationDto() { Location = "Ankara", PersonCount = 1, PhoneCount = 5 } }));

            await Task.CompletedTask;
        }
    }
}
