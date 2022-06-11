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
            context.LocationReports.Add(locationReport);
            return await context.SaveChangesAsync();
        }

        public IEnumerable<LocationReport> GetAll()
        {
            return context.LocationReports.AsEnumerable();
        }

        public LocationReport? GetById(Guid id)
        {
            return context.LocationReports.FirstOrDefault(c => c.Id == id);
        }

        public async Task<int> UpdateAsync(LocationReport locationReport)
        {
            context.LocationReports.Update(locationReport);

            return await context.SaveChangesAsync();
        }
    }
}
