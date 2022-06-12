using MediatR;

namespace PersonContactInfo.Application.Features.Contact.Commands
{
    public class RemoveContactCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
