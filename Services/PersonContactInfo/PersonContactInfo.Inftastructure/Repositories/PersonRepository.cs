using Microsoft.EntityFrameworkCore;
using PersonContactInfo.Application.Interface.Context;
using PersonContactInfo.Application.Interface.Repository;
using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Inftastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IApplicationDbContext context;

        public PersonRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync(Person person)
        {
            await context.Persons.AddAsync(person);

            return await context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllWithContactsAsync()
        {
            return await context.Persons.Include(c => c.Contacts).ToListAsync();
        }

        public async Task<Person?> GetByIdWithContactsAsync(Guid id)
        {
            return await context.Persons.Include(c => c.Contacts).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> RemoveAsync(Person person)
        {
            context.Persons.Remove(person);
            return await context.SaveChangesAsync();
        }
    }
}
