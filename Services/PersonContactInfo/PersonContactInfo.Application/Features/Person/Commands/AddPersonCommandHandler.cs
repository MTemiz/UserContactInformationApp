using MediatR;
using UserContactInformation.Application.Interface.Repository;

namespace UserContactInformation.Application.Features.Person.Commands
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, int>
    {
        private readonly IPersonRepository personRepository;

        public AddPersonCommandHandler(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public Task<int> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
