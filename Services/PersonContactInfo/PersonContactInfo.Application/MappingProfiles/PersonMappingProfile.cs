using AutoMapper;
using PersonContactInfo.Application.Features.Person.Commands;
using PersonContactInfo.Application.Features.Person.Dtos;
using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Application.MappingProfiles
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<AddPersonCommand, Person>();

            CreateMap<Person, PersonDto>();
        }
    }
}
