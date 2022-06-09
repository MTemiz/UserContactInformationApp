using MediatR;
using PersonContactInfo.Application.Features.Contact.Dtos;
using UserContactInformation.Application.Interface.Repository;

namespace UserContactInformation.Application.Features.Contact.Commands
{
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, ContactDto>
    {
        private readonly IContactRepository contactRepository;

        public AddContactCommandHandler(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public Task<ContactDto> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
