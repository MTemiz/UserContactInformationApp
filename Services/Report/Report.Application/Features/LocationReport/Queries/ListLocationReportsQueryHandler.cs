using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Report.Application.Features.LocationReport.Dtos;
using Report.Application.Interfaces.Repositories;

namespace Report.Application.Features.LocationReport.Queries
{
    public class ListLocationReportsQueryHandler : IRequestHandler<ListLocationReportsQuery, IEnumerable<LocationReportDto>>
    {
        private readonly ILocationReportRepository locationReportRepository;
        private readonly IMapper mapper;

        public ListLocationReportsQueryHandler(ILocationReportRepository locationReportRepository, IMapper mapper)
        {
            this.locationReportRepository = locationReportRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LocationReportDto>> Handle(ListLocationReportsQuery request, CancellationToken cancellationToken)
        {
            var locationReports = await locationReportRepository.GetAll().ToListAsync();

            var locationReportDtos = mapper.Map<IEnumerable<LocationReportDto>>(locationReports);

            return await Task.FromResult(locationReportDtos);

        }
    }
}
