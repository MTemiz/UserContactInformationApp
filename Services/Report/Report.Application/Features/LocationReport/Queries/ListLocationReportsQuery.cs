using MediatR;
using Report.Application.Features.LocationReport.Dtos;

namespace Report.Application.Features.LocationReport.Queries
{
    public class ListLocationReportsQuery : IRequest<IEnumerable<LocationReportDto>>
    {
    }
}
