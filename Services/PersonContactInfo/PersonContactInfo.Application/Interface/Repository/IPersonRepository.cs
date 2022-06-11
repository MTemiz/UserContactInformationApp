using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Application.Interface.Repository
{
    public interface IPersonRepository
    {
        Task<int> AddAsync(Person person);
        Task<int> RemoveAsync(Person person);

        Person? GetByIdWithContacts(Guid id);

        List<Person> GetAllWithContacts();
    }
}
