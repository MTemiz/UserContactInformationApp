using MediatR;
using Report.Application.Features.LocationReport.Dtos;

namespace Report.Application.Features.LocationReport.Commands
{
    public class RequestLocationReportCommand : IRequest<LocationReportDto>
    {
        public RequestLocationReportCommand()
        {
            RequestedDate = DateTime.Now;
        }
        public DateTime RequestedDate { get; }
    }
}
