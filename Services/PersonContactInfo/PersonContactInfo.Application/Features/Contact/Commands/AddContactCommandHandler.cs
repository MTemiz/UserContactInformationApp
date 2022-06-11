using AutoMapper;
using MediatR;
using PersonContactInfo.Application.Features.Contact.Dtos;
using UserContactInformation.Application.Interface.Repository;

namespace UserContactInformation.Application.Features.Contact.Commands
{
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, ContactDto>
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;

        public AddContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }

        public async Task<ContactDto> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Domain.Entities.Contact>(request);

            await contactRepository.AddAsync(contact);

            var contactDto = mapper.Map<ContactDto>(contact);

            return await Task.FromResult(contactDto);
        }
    }
}
