using MediatR;
using UserContactInformation.Application.Features.Person.Dtos;

namespace UserContactInformation.Application.Features.Person.Commands
{
    public class AddPersonCommand : IRequest<PersonDto>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
