using AutoMapper;
using MediatR;
using PersonContactInfo.Application.Exceptions;
using PersonContactInfo.Application.Features.Contact.Dtos;
using PersonContactInfo.Application.Interface.Repository;

namespace PersonContactInfo.Application.Features.Contact.Commands
{
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, ContactDto>
    {
        private readonly IContactRepository contactRepository;
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public AddContactCommandHandler(IContactRepository contactRepository, IMapper mapper, IPersonRepository personRepository)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
            this.personRepository = personRepository;
        }

        public async Task<ContactDto> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var person = await personRepository.GetByIdAsync(request.PersonId);

            if (person is null)
            {
                throw new NotFoundException("person not found");
            }

            var contact = mapper.Map<Domain.Entities.Contact>(request);

            await contactRepository.AddAsync(contact);

            var contactDto = mapper.Map<ContactDto>(contact);

            return await Task.FromResult(contactDto);
        }
    }
}
