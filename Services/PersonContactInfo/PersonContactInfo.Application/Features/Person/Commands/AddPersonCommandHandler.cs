using AutoMapper;
using MediatR;
using UserContactInformation.Application.Features.Person.Dtos;
using UserContactInformation.Application.Interface.Repository;

namespace UserContactInformation.Application.Features.Person.Commands
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, PersonDto>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public AddPersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public Task<PersonDto> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = mapper.Map<Domain.Entities.Person>(request);

            personRepository.AddAsync(person);

            return Task.FromResult(mapper.Map<PersonDto>(person));
        }
    }
}
