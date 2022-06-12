using Report.Domain.Entities;

namespace Report.Application.Interfaces.Repositories
{
    public interface ILocationReportRepository
    {
        Task<int> AddAsync(LocationReport locationReport);

        IQueryable<LocationReport> GetAll();

        Task<LocationReport?> GetByIdAsync(Guid id);

        Task<int> UpdateAsync(LocationReport locationReport);

        Task<LocationReport?> GetByIdWithResultsAsync(Guid id);
    }
}
