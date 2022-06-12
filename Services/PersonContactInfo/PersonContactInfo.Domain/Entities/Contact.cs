namespace PersonContactInfo.Domain.Entities
{
    public class Contact: BaseEntity
    {
        public Guid PersonId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
