using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonContactInfo.Application.Features.Contact.Commands;
using PersonContactInfo.Application.Features.Contact.Dtos;
using PersonContactInfo.Application.Features.Person.Commands;
using PersonContactInfo.Application.Features.Person.Dtos;
using PersonContactInfo.Application.Features.Person.Queries;
using System.Net.Mime;

namespace PersonContactInfo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class PersonContactController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonContactController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("addperson")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        public async Task<IActionResult> AddPerson(AddPersonCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        [Route("removeperson")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemovePerson(RemovePersonCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        [Route("addcontact")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactDto))]
        public async Task<IActionResult> AddContact(AddContactCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        [Route("removecontact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveContact(RemoveContactCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        [Route("listpersons")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonDto>))]
        public async Task<IActionResult> ListPersons()
        {
            return Ok(await mediator.Send(new ListPersonsQuery()));
        }

        [HttpGet]
        [Route("getpersondetailsbyid")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonDetailsById([FromQuery] GetPersonDetailsByIdQuery query)
        {
            return Ok(await mediator.Send(query));
        }
    }
}