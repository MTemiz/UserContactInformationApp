using MediatR;
using PersonContactInfo.Application.Exceptions;
using PersonContactInfo.Application.Interface.Repository;

namespace PersonContactInfo.Application.Features.Person.Commands
{
    public class RemovePersonCommandHandler : IRequestHandler<RemovePersonCommand, int>
    {
        private readonly IPersonRepository personRepository;

        public RemovePersonCommandHandler(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<int> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await personRepository.GetByIdWithContactsAsync(request.Id);

            if (person is null)
            {
                throw new NotFoundException();
            }

            await personRepository.RemoveAsync(person);

            return await Task.FromResult(0);
        }
    }
}
