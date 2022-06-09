using MediatR;

namespace UserContactInformation.Application.Features.Contact.Commands
{
    public class AddContactCommand : IRequest<int>
    {
        public Guid PersonId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
