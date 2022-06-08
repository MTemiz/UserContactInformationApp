using MediatR;

namespace UserContactInformation.Application.Features.Person.Commands
{
    public class AddPersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
