using Report.Domain.Entities;

namespace Report.Application.Interfaces.Repositories
{
    public interface ILocationReportResultRepository
    {
        Task AddAsync(LocationReportResult locationReportResult);
    }
}
