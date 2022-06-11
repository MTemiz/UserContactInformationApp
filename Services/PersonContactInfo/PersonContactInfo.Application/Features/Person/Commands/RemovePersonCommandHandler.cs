using MediatR;
using PersonContactInfo.Application.Exceptions;
using PersonContactInfo.Application.Interface.Repository;

namespace PersonContactInfo.Application.Features.Person.Commands
{
    public class RemovePersonCommandHandler : IRequestHandler<RemovePersonCommand, int>
    {
        private readonly IPersonRepository personRepository;
        private readonly IContactRepository contactRepository;

        public RemovePersonCommandHandler(IPersonRepository personRepository, IMediator mediator, IContactRepository contactRepository)
        {
            this.personRepository = personRepository;
            this.contactRepository = contactRepository;
        }

        public async Task<int> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await personRepository.GetByIdWithContactsAsync(request.Id);

            if (person is null)
            {
                throw new NotFoundException();
            }

            foreach (var contact in person.Contacts)
            {
                await contactRepository.RemoveAsync(contact);
            }

            await personRepository.RemoveAsync(person);

            return await Task.FromResult(0);
        }
    }
}
