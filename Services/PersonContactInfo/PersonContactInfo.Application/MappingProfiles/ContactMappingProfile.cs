using AutoMapper;
using PersonContactInfo.Application.Features.Contact.Dtos;
using UserContactInformation.Application.Features.Contact.Commands;
using UserContactInformation.Domain.Entities;

namespace PersonContactInfo.Application.MappingProfiles
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<AddContactCommand, Contact>();

            CreateMap<Contact, ContactDto>();
        }
    }
}
