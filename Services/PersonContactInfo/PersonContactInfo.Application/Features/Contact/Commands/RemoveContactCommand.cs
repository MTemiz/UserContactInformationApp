using MediatR;

namespace UserContactInformation.Application.Features.Contact.Commands
{
    public class RemoveContactCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
