namespace UserContactInformation.Domain.Entities
{
    public class Contact: BaseEntity
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
