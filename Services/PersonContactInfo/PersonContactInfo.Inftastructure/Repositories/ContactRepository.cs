using Microsoft.EntityFrameworkCore;
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
            await context.Contacts.AddAsync(contact);

            return await context.SaveChangesAsync();
        }

        public async Task<Contact?> GetByIdAsync(Guid id)
        {
            return await context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Contact>> GetByPersonIdAsync(Guid personId)
        {
            return await context.Contacts.Where(c => c.PersonId == personId).ToListAsync();
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
