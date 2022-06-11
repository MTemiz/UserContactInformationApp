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

        public async Task<PersonDto> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = mapper.Map<Domain.Entities.Person>(request);

            await personRepository.AddAsync(person);

            return await Task.FromResult(mapper.Map<PersonDto>(person));
        }
    }
}
