using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonContactInfo.Application.Features.Contact.Dtos;
using PersonContactInfo.Application.Features.Person.Queries;
using System.Net.Mime;
using UserContactInformation.Application.Features.Contact.Commands;
using UserContactInformation.Application.Features.Person.Commands;
using UserContactInformation.Application.Features.Person.Dtos;
using UserContactInformation.Application.Features.Person.Queries;

namespace UserContactInformation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonContactController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonContactController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name = "addperson")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        public async Task<IActionResult> AddPerson(AddPersonCommand command)
        {
            return Ok(await mediator.Send(command));
        }


        [HttpGet(Name = "removeperson")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemovePerson(RemovePersonCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpGet(Name = "addcontact")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactDto))]
        public async Task<IActionResult> AddContact(AddContactCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet(Name = "removecontact")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveContact(RemoveContactCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpGet(Name = "listpersons")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonDto>))]
        public async Task<IActionResult> ListPersons(ListPersonsQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        [HttpGet(Name = "getpersondetailsbyid")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        public async Task<IActionResult> GetPersonDetailsById(GetPersonDetailsByIdQuery query)
        {
            return Ok(await mediator.Send(query));
        }
    }
}