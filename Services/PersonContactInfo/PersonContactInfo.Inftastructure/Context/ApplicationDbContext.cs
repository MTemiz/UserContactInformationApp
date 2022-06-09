using Microsoft.EntityFrameworkCore;
using UserContactInformation.Application.Interface.Context;
using UserContactInformation.Domain.Entities;
using UserContactInformation.Inftastructure.Configuration;

namespace UserContactInformation.Inftastructure.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            builder.ApplyConfiguration(new ContactEntityTypeConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
