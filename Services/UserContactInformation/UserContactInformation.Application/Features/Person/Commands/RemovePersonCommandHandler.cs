using MediatR;
using UserContactInformation.Application.Interface.Repository;

namespace UserContactInformation.Application.Features.Person.Commands
{
    public class RemovePersonCommandHandler : IRequestHandler<RemovePersonCommand, int>
    {
        private readonly IPersonRepository personRepository;

        public RemovePersonCommandHandler(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public Task<int> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
