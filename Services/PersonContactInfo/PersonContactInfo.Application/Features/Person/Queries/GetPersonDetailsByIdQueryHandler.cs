using MediatR;
using UserContactInformation.Application.Features.Person.Dtos;
using UserContactInformation.Application.Interface.Repository;

namespace PersonContactInfo.Application.Features.Person.Queries
{
    public class GetPersonDetailsByIdQueryHandler : IRequestHandler<GetPersonDetailsByIdQuery, PersonDto>
    {
        private readonly IPersonRepository personRepository;

        public GetPersonDetailsByIdQueryHandler(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public Task<PersonDto> Handle(GetPersonDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
