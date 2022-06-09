using UserContactInformation.Application.Interface.Context;
using UserContactInformation.Application.Interface.Repository;
using UserContactInformation.Domain.Entities;

namespace UserContactInformation.Inftastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IApplicationDbContext context;

        public ContactRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
        }

        public void Remove(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
        }
    }
}
