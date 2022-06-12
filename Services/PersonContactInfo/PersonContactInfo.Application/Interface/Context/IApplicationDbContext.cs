using Microsoft.EntityFrameworkCore;
using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Application.Interface.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        Task<int> SaveChangesAsync();
    }
}
