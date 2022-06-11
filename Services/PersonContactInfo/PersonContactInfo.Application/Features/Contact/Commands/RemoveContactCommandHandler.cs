using AutoMapper;
using MediatR;
using PersonContactInfo.Application.Exceptions;
using PersonContactInfo.Application.Interface.Repository;

namespace PersonContactInfo.Application.Features.Contact.Commands
{
    internal class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand, int>
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;

        public RemoveContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await contactRepository.GetByIdAsync(request.Id);

            if (contact is null)
            {
                throw new NotFoundException();
            }

            await contactRepository.RemoveAsync(contact);

            return await Task.FromResult(0);
        }
    }
}
