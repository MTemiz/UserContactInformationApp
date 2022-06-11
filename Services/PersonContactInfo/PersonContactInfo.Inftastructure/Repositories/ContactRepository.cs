using PersonContactInfo.Application.Interface.Context;
using PersonContactInfo.Application.Interface.Repository;
using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Inftastructure.Repositories
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
