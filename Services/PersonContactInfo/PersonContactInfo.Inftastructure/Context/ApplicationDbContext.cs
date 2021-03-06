using Microsoft.EntityFrameworkCore;
using PersonContactInfo.Application.Interface.Context;
using PersonContactInfo.Domain.Entities;
using PersonContactInfo.Inftastructure.Configuration;

namespace PersonContactInfo.Inftastructure.Context
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

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
                else if(entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).LastUpdatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
