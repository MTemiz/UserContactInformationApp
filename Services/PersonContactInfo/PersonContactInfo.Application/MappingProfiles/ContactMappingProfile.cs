using AutoMapper;
using PersonContactInfo.Application.Features.Contact.Dtos;
using PersonContactInfo.Application.Features.Contact.Commands;
using PersonContactInfo.Domain.Entities;

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
