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

        public async Task<int> AddAsync(Contact contact)
        {
            context.Contacts.Add(contact);
            return await context.SaveChangesAsync();
        }

        public Contact? GetById(Guid id)
        {
            return context.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public List<Contact> GetByPersonId(Guid personId)
        {
            return context.Contacts.Where(c => c.PersonId == personId).ToList();
        }

        public async Task<int> RemoveAsync(Contact contact)
        {
            context.Contacts.Remove(contact);

            return await context.SaveChangesAsync();
        }

        public IQueryable<Contact> GetAll()
        {
            return context.Contacts.AsQueryable();
        }
    }
}
