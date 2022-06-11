using MediatR;
using PersonContactInfo.Application.Features.Person.Dtos;

namespace PersonContactInfo.Application.Features.Person.Commands
{
    public class AddPersonCommand : IRequest<PersonDto>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
