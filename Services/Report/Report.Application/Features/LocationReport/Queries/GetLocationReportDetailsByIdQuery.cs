using MediatR;
using Report.Application.Features.LocationReport.Dtos;

namespace Report.Application.Features.LocationReport.Queries
{
    public class GetLocationReportDetailsByIdQuery : IRequest<LocationReportDetailDto>
    {
        public Guid Id { get; set; }
    }
}
