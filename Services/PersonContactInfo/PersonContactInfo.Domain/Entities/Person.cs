namespace PersonContactInfo.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
