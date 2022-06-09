using MediatR;
using UserContactInformation.Application.Interface.Repository;

namespace UserContactInformation.Application.Features.Contact.Commands
{
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, int>
    {
        private readonly IContactRepository contactRepository;

        public AddContactCommandHandler(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public Task<int> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
