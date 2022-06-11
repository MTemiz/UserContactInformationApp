using Report.Application.Interfaces.Context;
using Report.Application.Interfaces.Repositories;
using Report.Domain.Entities;

namespace Report.Infrastructure.Repositories
{
    public class LocationReportResultRepository : ILocationReportResultRepository
    {
        private readonly IApplicationDbContext context;

        public LocationReportResultRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync(LocationReportResult locationReportResult)
        {
            context.LocationReportResults.Add(locationReportResult);
            return await context.SaveChangesAsync();
        }
    }
}
