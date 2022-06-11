using MediatR;
using Microsoft.AspNetCore.Mvc;
using Report.Application.Features.LocationReport.Commands;
using Report.Application.Features.LocationReport.Dtos;
using Report.Application.Features.LocationReport.Queries;
using System.Net.Mime;

namespace Report.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ReportController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("requestreport")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocationReportDto))]
        public async Task<IActionResult> RequestReport()
        {
            return Ok(await mediator.Send(new RequestLocationReportCommand()));
        }

        [HttpGet]
        [Route("listreports")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LocationReportDto>))]
        public async Task<IActionResult> ListReports()
        {
            return Ok(await mediator.Send(new ListLocationReportsQuery()));
        }

        [HttpGet]
        [Route("getreportdetailsbyid")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocationReportDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonDetailsById([FromQuery] GetLocationReportDetailsByIdQuery query)
        {
            return Ok(await mediator.Send(query));
        }
    }
}