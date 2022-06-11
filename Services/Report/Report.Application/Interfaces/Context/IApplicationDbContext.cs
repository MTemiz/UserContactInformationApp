using Microsoft.EntityFrameworkCore;
using Report.Domain.Entities;

namespace Report.Application.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<LocationReport> LocationReports { get; set; }
        public DbSet<LocationReportResult> LocationReportResults { get; set; }
        Task<int> SaveChangesAsync();
    }
}
