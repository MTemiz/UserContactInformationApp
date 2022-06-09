using MediatR;
using PersonContactInfo.Application.Features.Contact.Dtos;

namespace UserContactInformation.Application.Features.Contact.Commands
{
    public class AddContactCommand : IRequest<ContactDto>
    {
        public Guid PersonId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
