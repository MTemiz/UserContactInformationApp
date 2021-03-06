using PersonContactInfo.Application.Features.Contact.Dtos;

namespace PersonContactInfo.Application.Features.Person.Dtos
{
    public class PersonContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public ICollection<ContactDto> Contacts { get; set; }
    }
}
