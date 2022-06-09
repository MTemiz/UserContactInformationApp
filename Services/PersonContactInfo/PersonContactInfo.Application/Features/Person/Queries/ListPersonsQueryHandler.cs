using MediatR;
using UserContactInformation.Application.Features.Person.Dtos;
using UserContactInformation.Application.Interface.Repository;

namespace UserContactInformation.Application.Features.Person.Queries
{
    public class ListPersonsQueryHandler : IRequestHandler<ListPersonsQuery, IEnumerable<PersonDto>>
    {
        private readonly IPersonRepository personRepository;

        public ListPersonsQueryHandler(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public Task<IEnumerable<PersonDto>> Handle(ListPersonsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
