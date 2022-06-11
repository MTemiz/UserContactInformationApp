using Report.Domain.Entities;

namespace Report.Application.Interfaces.Repositories
{
    public interface ILocationReportRepository
    {
        Task<int> AddAsync(LocationReport locationReport);

        IEnumerable<LocationReport> GetAll();

        LocationReport? GetById(Guid id);
        Task<int> UpdateAsync(LocationReport locationReport);
    }
}
