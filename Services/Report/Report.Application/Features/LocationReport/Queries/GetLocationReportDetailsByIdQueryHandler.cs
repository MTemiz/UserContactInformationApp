using AutoMapper;
using MediatR;
using Report.Application.Exceptions;
using Report.Application.Features.LocationReport.Dtos;
using Report.Application.Interfaces.Repositories;

namespace Report.Application.Features.LocationReport.Queries
{
    public class GetLocationReportDetailsByIdQueryHandler : IRequestHandler<GetLocationReportDetailsByIdQuery, LocationReportDto>
    {
        private readonly ILocationReportRepository locationReportRepository;
        private readonly IMapper mapper;

        public GetLocationReportDetailsByIdQueryHandler(ILocationReportRepository locationReportRepository, IMapper mapper)
        {
            this.locationReportRepository = locationReportRepository;
            this.mapper = mapper;
        }

        public async Task<LocationReportDto> Handle(GetLocationReportDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var locationReport = await locationReportRepository.GetByIdAsync(request.Id);

            if (locationReport is null)
            {
                throw new NotFoundException();
            }

            var locationReportDto = mapper.Map<LocationReportDto>(locationReport);

            return await Task.FromResult(locationReportDto);
        }
    }
}
