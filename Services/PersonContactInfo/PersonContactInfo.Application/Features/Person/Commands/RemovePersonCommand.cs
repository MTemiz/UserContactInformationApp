using MediatR;

namespace PersonContactInfo.Application.Features.Person.Commands
{
    public class RemovePersonCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
