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
            context.Persons.Add(person);
            return await context.SaveChangesAsync();
        }

        public List<Person> GetAllWithContacts()
        {
            return context.Persons.Include(c => c.Contacts).ToList();
        }

        public Person? GetByIdWithContacts(Guid id)
        {
            return context.Persons.Include(c => c.Contacts).FirstOrDefault(c => c.Id == id);
        }

        public async Task<int> RemoveAsync(Person person)
        {
            context.Persons.Remove(person);
            return await context.SaveChangesAsync();
        }
    }
}
