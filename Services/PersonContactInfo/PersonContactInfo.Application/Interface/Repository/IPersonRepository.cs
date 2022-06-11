using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Application.Interface.Repository
{
    public interface IPersonRepository
    {
        Task<int> AddAsync(Person person);
        Task<int> RemoveAsync(Person person);

        Task<Person?> GetByIdWithContactsAsync(Guid id);

        Task<List<Person>> GetAllWithContactsAsync();
    }
}
