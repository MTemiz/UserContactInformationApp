using Microsoft.EntityFrameworkCore;
using UserContactInformation.Domain.Entities;

namespace UserContactInformation.Application.Interface.Persistence.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<Person> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        Task<int> SaveChangesAsync();
    }
}
