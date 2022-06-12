namespace PersonContactInfo.Application.Features.Contact.Dtos
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
