using MediatR;
using UserContactInformation.Application.Interface.Repository;

namespace UserContactInformation.Application.Features.Contact.Commands
{
    internal class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand, int>
    {
        private readonly IContactRepository contactRepository;

        public RemoveContactCommandHandler(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public Task<int> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
