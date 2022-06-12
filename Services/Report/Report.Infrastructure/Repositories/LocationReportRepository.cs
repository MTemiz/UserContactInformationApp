using Microsoft.EntityFrameworkCore;
using Report.Application.Interfaces.Context;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;

namespace Report.Infrastructure.Repositories
{
    public class LocationReportRepository : ILocationReportRepository
    {
        private readonly IApplicationDbContext context;

        public LocationReportRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(LocationReport locationReport)
        {
            await context.LocationReports.AddAsync(locationReport);

            await context.SaveChangesAsync();
        }

        public async Task<List<LocationReport>> GetAllAsync()
        {
            return await context.LocationReports.ToListAsync();
        }

        public async Task<LocationReport?> GetByIdAsync(Guid id)
        {
            return await context.LocationReports.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<LocationReport?> GetByIdWithResultsAsync(Guid id)
        {
            return await context.LocationReports.Include(c => c.ReportResults).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> UpdateAsync(LocationReport locationReport)
        {
            context.LocationReports.Update(locationReport);

            return await context.SaveChangesAsync();
        }
    }
}
