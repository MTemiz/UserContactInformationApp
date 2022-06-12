using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Application.Interface.Repository
{
    public interface IPersonRepository
    {
        Task AddAsync(Person person);
        Task RemoveAsync(Person person);
        Task<Person?> GetByIdWithContactsAsync(Guid id);
        Task<List<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(Guid id);
    }
}
