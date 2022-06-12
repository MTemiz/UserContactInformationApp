using AutoMapper;
using EventBus.Base.Abstraction;
using MediatR;
using Report.Application.Features.LocationReport.Dtos;
using Report.Application.IntegrationEvents;
using Report.Application.Interfaces.Repositories;

namespace Report.Application.Features.LocationReport.Commands
{
    public class RequestLocationReportCommandHandler : IRequestHandler<RequestLocationReportCommand, LocationReportDto>
    {
        private readonly ILocationReportRepository locationReportRepository;
        private readonly IMapper mapper;
        private readonly IEventBus eventBus;

        public RequestLocationReportCommandHandler(ILocationReportRepository locationReportRepository, IMapper mapper, IEventBus eventBus)
        {
            this.locationReportRepository = locationReportRepository;
            this.mapper = mapper;
            this.eventBus = eventBus;
        }

        public async Task<LocationReportDto> Handle(RequestLocationReportCommand request, CancellationToken cancellationToken)
        {
            var locationReport = mapper.Map<Domain.Entities.LocationReport>(request);

            await locationReportRepository.AddAsync(locationReport);

            var locationReportDto = mapper.Map<LocationReportDto>(locationReport);

            eventBus.Publish(new LocationReportRequestedIntegrationEvent(locationReportDto.Id));

            return await Task.FromResult(locationReportDto);
        }
    }
}
