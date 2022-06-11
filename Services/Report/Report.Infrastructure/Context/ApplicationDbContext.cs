using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Report.Application.Interfaces.Context;
using Report.Domain.Entities;
using Report.Infrastructure.Configuration;

namespace Report.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LocationReportEntityTypeConfiguration());
            builder.ApplyConfiguration(new LocationReportResultEntityTypeConfiguration());

            builder.Entity<LocationReportResult>().HasIndex(c => c.LocationReportId).IsUnique();

            base.OnModelCreating(builder);
        }

        public DbSet<LocationReport> LocationReports { get; set; }
        public DbSet<LocationReportResult> LocationReportResults { get; set; }

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
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).LastUpdatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
