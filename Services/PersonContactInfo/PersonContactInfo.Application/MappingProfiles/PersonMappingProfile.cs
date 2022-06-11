using AutoMapper;
using UserContactInformation.Application.Features.Person.Commands;
using UserContactInformation.Application.Features.Person.Dtos;
using UserContactInformation.Domain.Entities;

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
