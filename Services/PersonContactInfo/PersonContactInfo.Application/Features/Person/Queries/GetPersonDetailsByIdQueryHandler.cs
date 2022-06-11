using AutoMapper;
using MediatR;
using PersonContactInfo.Application.Exceptions;
using UserContactInformation.Application.Features.Person.Dtos;
using UserContactInformation.Application.Interface.Repository;

namespace PersonContactInfo.Application.Features.Person.Queries
{
    public class GetPersonDetailsByIdQueryHandler : IRequestHandler<GetPersonDetailsByIdQuery, PersonDto>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public GetPersonDetailsByIdQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public Task<PersonDto> Handle(GetPersonDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var person = personRepository.GetByIdWithContacts(request.Id);

            if (person is null)
            {
                throw new NotFoundException();
            }

            var personDto = mapper.Map<PersonDto>(person);

            return Task.FromResult(personDto);
        }
    }
}
