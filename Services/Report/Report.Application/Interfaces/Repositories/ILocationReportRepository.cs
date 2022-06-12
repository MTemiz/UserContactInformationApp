using Report.Domain.Entities;

namespace Report.Application.Interfaces.Repositories
{
    public interface ILocationReportRepository
    {
        Task AddAsync(LocationReport locationReport);

        Task<List<LocationReport>> GetAllAsync();

        Task<LocationReport?> GetByIdAsync(Guid id);

        Task<int> UpdateAsync(LocationReport locationReport);

        Task<LocationReport?> GetByIdWithResultsAsync(Guid id);
    }
}
