using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonContactInfo.Application.Features.Person.Dtos;
using PersonContactInfo.Application.Interface.Repository;

namespace PersonContactInfo.Application.Features.Person.Queries
{
    public class ListPersonsQueryHandler : IRequestHandler<ListPersonsQuery, List<PersonDto>>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public ListPersonsQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<List<PersonDto>> Handle(ListPersonsQuery request, CancellationToken cancellationToken)
        {
            var personList = await personRepository.GetAll().ToListAsync();

            var personDtoList = mapper.Map<List<PersonDto>>(personList);

            return await Task.FromResult(personDtoList);
        }
    }
}
