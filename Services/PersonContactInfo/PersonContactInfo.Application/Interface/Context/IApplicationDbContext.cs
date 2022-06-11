using Microsoft.EntityFrameworkCore;
using UserContactInformation.Domain.Entities;

namespace UserContactInformation.Application.Interface.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        Task<int> SaveChangesAsync();
    }
}
