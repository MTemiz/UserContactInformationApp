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

        public async Task<int> AddAsync(LocationReport locationReport)
        {
            await context.LocationReports.AddAsync(locationReport);

            return await context.SaveChangesAsync();
        }

        public IQueryable<LocationReport> GetAll()
        {
            return context.LocationReports.AsQueryable();
        }

        public async Task<LocationReport?> GetByIdAsync(Guid id)
        {
            return await context.LocationReports.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> UpdateAsync(LocationReport locationReport)
        {
            context.LocationReports.Update(locationReport);

            return await context.SaveChangesAsync();
        }
    }
}
